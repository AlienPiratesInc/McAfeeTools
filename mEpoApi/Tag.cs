/*

 * User: "Alien Pirates Inc"
 * Date: 9/12/2012
 * Updated: 2/22/2013
 * Email: alienpiratesinc@gmail.com

 */
 
using System;

namespace mEpoApi
{
	/// <summary>
	/// Description of Tag.
	/// </summary>
	public class Tag
	{
		private string _id="";
		private string _Name="";
		private string _Notes="";
		public Tag(string id,string name,string notes)
		{
			_id=id;
			_Name=name;
			_Notes=notes;
		}
		

		public string id { get{return this._id;}}
		public string name { get{return this._Name;}}
		public string note { get{return this._Notes;}}
	
		public override string ToString()
		{
			return string.Format("[Tag Id={0}, Name={1}, Notes={2}]", _id, _Name, _Notes);
		}

	}
}
