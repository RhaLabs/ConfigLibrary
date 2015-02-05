/*
 * Created by SharpDevelop.
 * User: bcrawford
 * Date: 5/13/2014
 * Time: 2:28 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ConfigLibrary.Entity
{
  /// <summary>
  /// Description of MailEntity.
  /// </summary>
  public abstract class MailEntity : EntityInterface
  {
    protected string hostName;
    
    protected int port;
    
    protected string socket;
    
    protected string userName;
    
    protected string userPassword;
    
    //protected System.Collections.Generic.Dictionary< string, string > addresses;
    
    protected System.Collections.Generic.IEnumerable< MailBox > mailBoxes;
    
    public MailEntity()
    {
      
    }
    
    public virtual string ClassName
    {
      get {return "MailEntity"; }
    }
    
    public virtual string HostName 
    {
      get { return hostName; }
      set { hostName = value; }
    }
    
    public virtual int Port
    {
      get { return port; }
      set { port = value; }
    }
    
    public virtual string Socket
    {
      get { return socket; }
      set { socket = value; }
    }
    
    public virtual string UserName
    {
      get { return userName; }
      set { userName = value; }
    }
    
    public virtual string UserPassword
    {
      get { return userPassword; }
      set { userPassword = value; }
    }
    
//    public System.Collections.Generic.Dictionary< string, string > Addresses
//    {
//      get { return this.addresses; }
//      set { this.addresses = value; }
//    }
    
    public virtual System.Collections.Generic.IEnumerable< MailBox > MailBoxes
    {
      get { return this.mailBoxes; }
      set { this.mailBoxes = value; }
    }
  }
}
