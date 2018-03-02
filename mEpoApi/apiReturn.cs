/*

 * User: "Alien Pirates Inc"
 * Date: 9/12/2012
 * Email: alienpiratesinc@gmail.com

 */
using System;

namespace mEpoApi
{
	/// <summary>
	/// 
    /// This how data is returned from the 
	/// api calling functions.
    /// 
    /// </summary>
	public class apiReturn
	{
		
		string mStatus;		
		public string Status {
			get { return mStatus; }
			set { mStatus = value; }
		}
		
		string mData;
		
		public string Data {
			get { return mData; }
			set { mData = value; }
		}
		
		
		
		
	}
}
