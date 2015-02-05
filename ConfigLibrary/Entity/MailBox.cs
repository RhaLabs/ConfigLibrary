/*
 * Created by SharpDevelop.
 * User: bcrawford
 * Date: 8/6/2014
 * Time: 11:28 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ConfigLibrary.Entity
{
  /// <summary>
  /// Description of Class1.
  /// </summary>
  public abstract class MailBox : Microsoft.Exchange.WebServices.Data.Mailbox, EntityInterface
  {
    protected System.Collections.Generic.List< string > folders;
    
    protected string address;
    
    public MailBox()
    {
      
    }
    
    public virtual string ClassName
    {
      get {return "MailBox"; }
    }
    
    public virtual string Address
    {
      get { return this.address; }
      set { this.address = value; }
    }
    
    public virtual System.Collections.Generic.List< string > Folders
    {
      get { return this.folders; }
      set { this.folders = value; }
    }
    
  }
}
