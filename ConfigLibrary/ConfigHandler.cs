/*
 * Created by SharpDevelop.
 * User: bcrawford
 * Date: 5/13/2014
 * Time: 12:56 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using ConfigLibrary.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security;

namespace ConfigLibrary
{
  public abstract class ConfigHandler
  {
    protected string filePath;

    protected string jsonString;

    protected Configuration configuration;

    public ConfigHandler()
    {

    }

    public ConfigHandler(string pathToFile)
    {
      jsonString = System.IO.File.ReadAllText(pathToFile);

      filePath = pathToFile;
    }

    #region Public Properties
    public virtual string Version
    {
      get { return configuration.Version; }
      set { configuration.Version = value; }
    }

    public virtual string ConfigFilePath {
      get { return filePath; }
      set { filePath = value; }
    }

//    public System.Collections.Generic.Dictionary< string, string > Addresses
//    {
//      get { return configuration.Mail.Addresses; }
//      set { configuration.Mail.Addresses = value; }
//    }

    public virtual System.Collections.Generic.IEnumerable< MailBox > MailBoxes
    {
      get { return configuration.Mail.MailBoxes; }
      set { configuration.Mail.MailBoxes = value; }
    }

    public virtual string MailHost
    {
      get
      {
        ConfigLibrary.Entity.MailEntity mail = configuration.Mail;
        return  mail.HostName;
      }
    }

    public virtual string MailUser
    {
      get
      {
        var mail = configuration.Mail;
        return mail.UserName;
      }
    }

    public virtual string MailPass
    {
      get
      {
        ConfigLibrary.Entity.MailEntity mail = configuration.Mail;
        return mail.UserPassword;
      }
    }

    public virtual int MailPort
    {
      get
      {
        ConfigLibrary.Entity.MailEntity mail = configuration.Mail;
        return mail.Port;
      }
    }

    public virtual string SqlHost
    {
      get
      {
        ConfigLibrary.Entity.DataBaseEntity data = configuration.Database;
        return data.HostName;
      }
    }

    public virtual string SqlUser
    {
      get
      {
        ConfigLibrary.Entity.DataBaseEntity data = configuration.Database;
        return data.UserName;
      }
    }

    public virtual string SqlPass
    {
      get
      {
        ConfigLibrary.Entity.DataBaseEntity data = configuration.Database;
        return data.UserPassword;
      }
    }

    public virtual string SqlDatabase
    {
      get
      {
        ConfigLibrary.Entity.DataBaseEntity data = configuration.Database;
        return data.DataBase;
      }
    }

    public virtual int SqlPort
    {
      get
      {
        ConfigLibrary.Entity.DataBaseEntity data = configuration.Database;
        return data.Port;
      }
    }

    public virtual System.Collections.Generic.Dictionary< string, string > List
    {
      get
      {
        var list = this.configuration.collection;
        return list.List;
      }
    }

    #endregion

    #region Fill Data

    /// <summary>
    /// Enters all of the required data for the Mail Server
    /// </summary>
    /// <param name="HostName">Mail server name</param>
    /// <param name="LoginName">The login name to use</param>
    /// <param name="Password">The password to use, enter in as plain text</param>
    /// <param name="Port">the port to connect to the mail server.  IMAP is typically 25</param>
    public virtual void AddMailInfo (string HostName, string LoginName, string Password, int Port)
    {
      ConfigLibrary.Entity.MailEntity mail = configuration.Mail;
      mail.HostName = HostName;
      mail.UserName = LoginName;
      mail.UserPassword = Password;
      mail.Port = Port;
    }

    /// <summary>
    /// Enters info for the TCP data server.  Not Yet Implemented
    /// </summary>
    /// <param name="HostName">The remote Server host to connect</param>
    /// <param name="Port">The remote port</param>
    public virtual void AddDataInfo (string HostName, int ServerPort)
    {
      ConfigLibrary.Entity.DataBaseEntity data = configuration.Database;
      data.HostName = HostName;
      data.Port = ServerPort;
    }

    /// <summary>
    /// Enters info to connect to a MySql server
    /// </summary>
    /// <param name="Host"></param>
    /// <param name="Username"></param>
    /// <param name="Password"></param>
    /// <param name="Database"></param>
    public virtual void AddSqlInfo (string Host, string Username, string Password, string Database, int Port)
    {
      ConfigLibrary.Entity.DataBaseEntity data = configuration.Database;
      data.HostName = Host;
      data.UserName = Username;
      data.UserPassword = Password;
      data.DataBase = Database;
      data.Port = Port;
    }

    #endregion

    #region Public Out procedures

    /// <summary>
    /// Returns MySql info, the calling function must use th 'out' keyword in its signature
    /// example: Someobject.GetSqlInfo(out variable, out varibale2, out variable3, out varibale4)
    /// </summary>
    /// <param name="Host"></param>
    /// <param name="Username"></param>
    /// <param name="Password"></param>
    /// <param name="Database"></param>
    public virtual void GetSqlInfo (out string Host, out string Username, out string Password, out string Database, out int Port)
    {
      ConfigLibrary.Entity.DataBaseEntity data = configuration.Database;
      Host = data.HostName;
      Username = data.UserName;
      Password = data.UserPassword;
      Database = data.DataBase;
      Port = data.Port;
    }

    /// <summary>
    /// Returns Mail info, the calling function must use th 'out' keyword in its signature
    /// example: Someobject.GetMailInfo(out variable, out varibale2, out variable3, out varibale4)
    /// </summary>
    /// <param name="HostName"></param>
    /// <param name="LoginName"></param>
    /// <param name="Password"></param>
    /// <param name="Port"></param>
    public virtual void GetMailInfo (out string HostName, out string LoginName, out string Password, out int Port)
    {
      ConfigLibrary.Entity.MailEntity mail = configuration.Mail;
      HostName = mail.HostName;
      LoginName = mail.UserName;
      Password = mail.UserPassword;
      Port = mail.Port;
    }

    /// <summary>
    /// Returns Mail info for EWS, the calling function must use th 'out' keyword in its signature
    /// </summary>
    /// <param name="LoginName"></param>
    /// <param name="Password"></param>
    public virtual void GetMailInfo (out string LoginName, out string Password)
    {
      ConfigLibrary.Entity.MailEntity mail = configuration.Mail;
      LoginName = mail.UserName;
      Password = mail.UserPassword;
    }

    #endregion

    #region Save

    public virtual void SaveConfig (string FilePath, Configuration config)
    {
      FilePath = WellFormedFilePath(FilePath);

      if (config == null) {
        config = this.configuration;
      }

      File.WriteAllText(FilePath, JsonConvert.SerializeObject(config,Formatting.Indented));
    }

    /// <summary>
    /// Serializes current config settings to the specified config file in binary format.
    /// </summary>
    /// <param name="FilePath">Path where to save the file</param>
    public virtual void SaveConfig (string FilePath)
    {
      SaveConfig(FilePath, null);
    }

    /// <summary>
    /// Save the configuration to the already specified config file
    /// </summary>
    public virtual void SaveConfig ()
    {
      if (string.IsNullOrEmpty(filePath)) {
        filePath = @".";
      }
      SaveConfig(filePath);
    }

    private string WellFormedFilePath (string path)
    {
      var regex = new System.Text.RegularExpressions.Regex(@"\.json$", System.Text.RegularExpressions.RegexOptions.IgnoreCase);

      if(regex.IsMatch(path)){
        return path;
      }

      return path  + "\\config.json";
    }

    #endregion
  }
}