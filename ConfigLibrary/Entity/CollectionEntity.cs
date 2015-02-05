/*
 * Created by SharpDevelop.
 * User: bcrawford
 * Date: 7/24/2014
 * Time: 1:00 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace ConfigLibrary.Entity
{
  /// <summary>
  /// Description of CollectionEntity.
  /// </summary>
  public abstract class CollectionEntity : EntityInterface
  {
    
    protected System.Collections.Generic.Dictionary< string, string > list;
    
    public CollectionEntity()
    {
      list = new System.Collections.Generic.Dictionary< string, string >();
    }
    
    public virtual string ClassName
    {
      get { return "CollectionEntity"; }
    }
    
    public virtual System.Collections.Generic.Dictionary< string, string > List
    {
      get { return this.list; }
      set { this.list = value; }
    }
    

  }
}
