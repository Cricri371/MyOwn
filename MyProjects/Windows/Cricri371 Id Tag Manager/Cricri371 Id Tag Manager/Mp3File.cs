/*
 * Created by SharpDevelop.
 * User: Christophe Charanson
 * Date: 3/05/2007
 * Time: 21:01
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.IO;
using System.Text;

namespace Cricri371_Id_Tag_Manager
{
	/// <summary>
	/// Description of Mp3File.
	/// </summary>
	public class Mp3File
	{
		string title;
		string artist;
		string album;
		byte track;
		string year;
		string comment;
		byte genre;
		bool hasIDTag;
		string url;
		string composer;
		string encodedBy;
		string copyright;
		string orgArtist;
		
		public Mp3File()
		{
		}
		
		#region Properties
		public string OrgArtist 
		{
			get{return orgArtist;}
			set{orgArtist=value;}
		}
		public string Copyright 
		{
			get{return copyright;}
			set{copyright=value;}
		}
		public string EncodedBy 
		{
			get{return encodedBy;}
			set{encodedBy=value;}
		}
		
		public string Composer 
		{
			get{return composer;}
			set{composer=value;}
		}
		
		public string URL 
		{
			get{return url;}
			set{url=value;}
		}
		
		public bool HasIDTag 
		{
			get{return hasIDTag;}
			set{hasIDTag=value;}
		}
		
		public byte Genre 
		{
			get{return genre;}
			set{genre=value;}
		}
		
		public string Comment 
		{
			get{return comment;}
			set{comment=value;}
		}
		
		public string Year 
		{
			get{return year;}
			set{year=value;}
		}
		
		public byte Track 
		{
			get { return track;}
			set { track=value;}
		}
		
		public string Album 
		{
			get{return album;}
			set{album=value;}
		}
		
		public string Artist 
		{
			get{return artist;}
			set{artist=value;}
		}
		
		public string Title 
		{
			get{return title;}
			set{title=value;}
		}
		#endregion
		
		#region ClearProperties
		public void ClearProperties()
		{
			title="";
			artist="";
			album="";
			track=0;
			year="";
			comment="";
			genre=0;
			hasIDTag=false;
			url="";
			composer="";
			encodedBy="";
			copyright="";
			orgArtist="";
		}
		#endregion
		
		#region ReadV1
		public void ReadV1(string fullPathFile)
		{
			// Read the 128 byte ID3 tag into a byte array
			FileStream fs = new FileStream(fullPathFile,FileMode.Open);
			byte[] b=new byte[128];

			fs.Seek(-128,SeekOrigin.End);
			fs.Read(b,0,128);
			fs.Close();
  
			Encoding instEncoding=new ASCIIEncoding();	// Encoding is an Abstract class
			string id3Tag=instEncoding.GetString(b);	// Convert the Byte Array to a String
  
			// If there is an attached ID3 v1.x TAG then read it 
			if(id3Tag.Substring(0,3).ToUpper()=="TAG")
			{
				title=id3Tag.Substring(3,30).Trim();
				artist=id3Tag.Substring(33,30).Trim();
				album=id3Tag.Substring(63,30).Trim();
				year=id3Tag.Substring(93,4).Trim();
				comment=id3Tag.Substring(97,28).Trim();
  
				// Get the track number if TAG conforms to ID3 v1.1
				if(id3Tag[125]== 0)
					track=b[126];
				else
					track=0;

				genre=b[127];
				
				hasIDTag=true;
			}
			else
				hasIDTag=false;
		}
		#endregion
		
		#region UpdateV1
		public void UpdateV1(string fullPathFile)
		{
			// Ensure all properties are correct size
			if(title.Length>30)
				title=title.Substring(0,30);
			if(artist.Length>30)	
				artist=artist.Substring(0,30);
			if(album.Length>30)	
				album=album.Substring(0,30);
			if(year.Length>4)
				year=year.Substring(0,4);
			if(comment.Length>28)
				comment=comment.Substring(0,28);
      
			// Build a new ID3 Tag (128 Bytes)
			byte[] tagByteArray=new byte[128];
			
			for(int i=0; i<tagByteArray.Length; i++)
				tagByteArray[i]=0; // Initialise array to nulls
  
			// Convert the Byte Array to a String
			Encoding  instEncoding=new ASCIIEncoding();	// Encoding is an Abstract class
			
			// Copy "TAG" to Array
			byte[] workingByteArray=instEncoding.GetBytes("TAG"); 
			Array.Copy(workingByteArray,0,tagByteArray,0,workingByteArray.Length);
			
			// Copy Title to Array
			workingByteArray=instEncoding.GetBytes(title.Trim());
			Array.Copy(workingByteArray,0,tagByteArray,3,workingByteArray.Length);
			
			// Copy Artist to Array
			workingByteArray=instEncoding.GetBytes(artist.Trim());
			Array.Copy(workingByteArray,0,tagByteArray,33,workingByteArray.Length);
			
			// Copy Album to Array
			workingByteArray=instEncoding.GetBytes(album.Trim());
			Array.Copy(workingByteArray,0,tagByteArray,63,workingByteArray.Length);
			
			// Copy Year to Array
			workingByteArray=instEncoding.GetBytes(year.Trim());
			Array.Copy(workingByteArray,0,tagByteArray,93,workingByteArray.Length);
			
			// Copy Comment to Array
			workingByteArray=instEncoding.GetBytes(comment.Trim());
			Array.Copy(workingByteArray,0,tagByteArray,97,workingByteArray.Length);
			
			// Copy Track and Genre to Array
			tagByteArray[126]=track;
			tagByteArray[127]=genre;
  
			// Replace the final 128 Bytes with our new ID3 tag
			FileStream oFileStream=new FileStream(fullPathFile,FileMode.Open);
			
			if(hasIDTag)
				oFileStream.Seek(-128,SeekOrigin.End);
			else
				oFileStream.Seek(0,SeekOrigin.End);
			
			// Write the buffer and close the file
			oFileStream.Write(tagByteArray,0,128);
			
			oFileStream.Close();
			
			hasIDTag = true;
		}
		#endregion
		
		#region CleanV1
		public void CleanV1(string fullPathFile)
		{
			if(!hasIDTag)
				return;
			
//			// Read the file and write the content without the ID3v1 tag in a temporary file
//			byte[]b=Tools.ReadMp3WithoutID3(fullPathFile,ID3Type.ID3v1);
//			
//			Tools.WriteTemp(b);
//			
//			// Delete the current file and replace it by the new one (the temp file)
//			File.Delete(fullPathFile);
//			File.Move(Tools.TEMPPATH,fullPathFile);
			
			hasIDTag=false;
		}
		#endregion
		
		#region ReadV2
		public void ReadV2(string fullPathFile)
		{
			// Read the 256 byte ID3 tag into a byte array
			FileStream 	fs=new FileStream(fullPathFile,FileMode.Open,FileAccess.Read,FileShare.Read);
			
			string valTag="";			// The value we are searching for
			int f=1;
			byte[] b=new byte[4];		// The data we are reading
			int[] nb=new int[4];

			fs.Read(b,0,3);			// Read the first three byte
			
			Encoding instEncoding = new ASCIIEncoding();
			
			string filetype=instEncoding.GetString(b);	// Transform the byte into a string
			
			// If this string begin with ID3 we have Id3v2
			if(filetype.StartsWith("ID3"))
			{
				string flag="";
				int i=0;

				fs.Seek(6,SeekOrigin.Begin);
				fs.Read(b,0,4);

				nb[3]=b[3]|((b[2] & 1)<<7);
				nb[2]=((b[2]>>1)&63)|((b[1]&3)<<6);
				nb[1]=((b[1]>>2)&31)|((b[0]&7)<<5);
				nb[0]=((b[0]>>3)&15);

				ulong FrameSize=10+(ulong)nb[3]|((ulong)nb[2]<<8)|((ulong)nb[1]<<16)|((ulong)nb[0]<<24) ;
				int TagSize=Convert.ToInt32(FrameSize);

				while(i<TagSize&&f>0)
				{	
					i+=10;
					fs.Seek(i,SeekOrigin.Begin);
					fs.Read(b,0,4);
					flag=instEncoding.GetString(b);
					fs.Seek(i+4,SeekOrigin.Begin);
					fs.Read(b,0,4);

					f=Convert.ToInt32(((uint)b[0]<<24)+((uint)b[1]<<16)+((uint)b[2]<<8)+((uint)b[3]));
			
					byte[] s=new byte[f];
					fs.Seek(i+10, SeekOrigin.Begin);
					fs.Read(s,0,f);
					Decoder d=Encoding.UTF8.GetDecoder();
				
					char[] chars=new Char[d.GetCharCount(s,0,f)];
					int charLen=d.GetChars(s,0,s.Length,chars,0);

					valTag="";
					
					for(int j=0;j<chars.Length;j++)
					{		
						if(chars[j].ToString()!="\0")
							valTag+=chars[j].ToString();
					}
					
					/* Search for the correct tag */
					switch(flag) 
					{
						case "TENC":	// Encoded
							encodedBy=valTag.Trim();
							break;
						case "WXXX":	// URL
							URL=valTag.Trim();
							break;
						case "TCOP":	// Copyright
							copyright=valTag.Trim();
							break;						
						case "TOPE":	// Org Artist
							orgArtist=valTag.Trim();
							break;
						case "TCOM":	// Composer
							composer=valTag.Trim();
							break;
						case "COMM":	// Comment
							comment=valTag.Trim();
							break;
						case "TYER":	// Year
							year=valTag.Trim();
							break;						
						case "TIT2":	// Titre
							title=valTag.Trim();
							break;
						case "TRCK":	// TrackNumber
							track=Convert.ToByte(valTag.Trim());
							break;
						case "TPE1":	// Artist
							artist=valTag.Trim();
							break;
						case "TALB":	// Album
							album=valTag.Trim();
							break;						
						case "TCON":	// Genre
							genre=Convert.ToByte(valTag.Trim().Substring(1,2));
							break;
					}
					i+=f;
				}
				
				hasIDTag=true;
			}
			else
				hasIDTag=false;
			
			fs.Close();
		}
		#endregion
		
		#region CleanV2
		public void CleanV2(string fullPathFile)
		{
			if(!hasIDTag)
				return;
			
//			// Read the file and write the content without the ID3v1 tag in a temporary file
//			byte[]b=Tools.ReadMp3WithoutID3(fullPathFile,ID3Type.ID3v1);
//			
//			Tools.WriteTemp(b);
//			
//			// Delete the current file and replace it by the new one (the temp file)
//			File.Delete(fullPathFile);
//			File.Move(Tools.TEMPPATH,fullPathFile);
			
			hasIDTag=false;
		}
		#endregion
	}
}
