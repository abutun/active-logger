/*  * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *
*																		*
*	Copyright (C) 2007  Ahmet BUTUN (butun180@hotmail.com)				*
*	http://www.ahmetbutun.net									        *
*																		*
*	This program is free software; you can redistribute it and/or		*
*	modify it under the terms of the GNU General Public License as		*
*	published by the Free Software Foundation; either version 2 of		*
*	the License, or (at your option) any later version.					*
*																		*
*	This program is distributed in the hope that it will be useful,		*
*	but WITHOUT ANY WARRANTY; without even the implied warranty of		*
*	MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU	*
*	General Public License for more details.							*
*																		*
*	You should have received a copy of the GNU General Public License	*
*	along with this program; if not, write to the Free Software			*
*	Foundation, Inc., 675 Mass Ave, Cambridge, MA 02139, USA.			*
*																		*
* * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * * *  */

using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace ActiveLogger
{
    /// <summary>
    /// Utility class for Serialization of Objects
    /// </summary>
    public class Serializer
    {
        /// <summary>
        /// Serializes an object into a binary file
        /// </summary>
        /// <param name="Object">Object to be serialized</param>
        /// <param name="FileName">File name to serialize object into</param>
        public static void Serialize(object Object, string FileName)
        {
            //Get a binary formatter
            BinaryFormatter bformatter = new BinaryFormatter();

            //Open a file stream to a new serialization file
            Stream stream = File.Open(FileName, FileMode.Create);

            //Serialize the given object into the file
            bformatter.Serialize(stream, Object);

            //Close the file stream
            stream.Close();
        }
        /// <summary>
        /// Deserialize an object from a file
        /// </summary>
        /// <param name="FileName">File name to deserialize object from</param>
        /// <returns>Deserialized Object (may require casting to desired type)</returns>
        public static object Deserialize(string FileName)
        {
            //Get a binary formatter
            BinaryFormatter bformatter = new BinaryFormatter();

            //Open a file stream to the serialization file
            Stream stream = File.Open(FileName, FileMode.Open);

            //Deserialize the object from the file
            object dObject = bformatter.Deserialize(stream);

            //Close the file stream
            stream.Close();

            //return the deserialized object
            return dObject;
        }
    }
}
