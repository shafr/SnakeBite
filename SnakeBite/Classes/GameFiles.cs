﻿using System.IO;
using System.Xml.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeBite
{
    [XmlType("GameFiles")]
    public class GameFiles
    {
        [XmlArray("FileList")]
        public List<GameFile> FileList = new List<GameFile>();

        public void Load(string FileName)
        {
            XmlSerializer x = new XmlSerializer(typeof(GameFiles));
            StreamReader s = new StreamReader(FileName);
            GameFiles g = (GameFiles)x.Deserialize(s);
            s.Close();

            foreach (GameFile f in g.FileList)
            {
                FileList.Add(f);
            }
        }

        public void Save(string FileName)
        {
            XmlSerializer x = new XmlSerializer(typeof(GameFiles));
            StreamWriter s = new StreamWriter(FileName);
            x.Serialize(s, this);
            s.Close();
        }
    }

    [XmlType("GameFile")]
    public class GameFile
    {
        [XmlAttribute("QarFile")]
        public string QarFile { get; set; }

        [XmlAttribute("FilePath")]
        public string FilePath { get; set; }

        [XmlAttribute("FileHash")]
        public ulong FileHash { get; set; }
    }
}