/*
 * Created by SharpDevelop.
 * User: bcrawford
 * Date: 5/13/2014
 * Time: 4:14 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using ConfigLibrary.Entity;

namespace ConfigLibrary
{
  /// <summary>
  /// Description of Configuration.
  /// </summary>
  public abstract class Configuration
  {
    protected DataBaseEntity database;
    
    protected MailEntity mail;
    
    protected CollectionEntity list;
    
    protected string version;
    
    public Configuration()
    {

    }
    
    public virtual DataBaseEntity Database
    {
      get { return database; }
      set { database = value; }
    }
    
    public virtual MailEntity Mail
    {
      get { return mail; }
      set { mail = value; }
    }
    
    public virtual string Version
    {
      get { return version; }
      set { version = value; }
    }
    
    public virtual CollectionEntity collection
    {
      get { return list; }
      set { list = value; }
    }
  }
}
