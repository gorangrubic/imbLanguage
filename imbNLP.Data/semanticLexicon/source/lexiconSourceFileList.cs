// --------------------------------------------------------------------------------------------------------------------
// <copyright file="lexiconSourceFileList.cs" company="imbVeles" >
//
// Copyright (C) 2017 imbVeles
//
// This program is free software: you can redistribute it and/or modify
// it under the +terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see http://www.gnu.org/licenses/. 
// </copyright>
// <summary>
// Project: imbNLP.Data
// Author: Goran Grubic
// ------------------------------------------------------------------------------------------------------------------
// Project web site: http://blog.veles.rs
// GitHub: http://github.com/gorangrubic
// Mendeley profile: http://www.mendeley.com/profiles/goran-grubi2/
// ORCID ID: http://orcid.org/0000-0003-2673-9471
// Email: hardy@veles.rs
// </summary>
// ------------------------------------------------------------------------------------------------------------------
namespace imbNLP.Data.semanticLexicon.source
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;
    using BrightstarDB.EntityFramework;
    using imbACE.Core.commands.menu;
    using imbACE.Core.core;
    using imbACE.Core.operations;
    using imbACE.Services.console;
    using imbACE.Services.terminal;
    using imbNLP.Data.extended.domain;
    using imbNLP.Data.extended.unitex;
    using imbNLP.Data.semanticLexicon.core;
    using imbNLP.Data.semanticLexicon.explore;
    using imbNLP.Data.semanticLexicon.morphology;
    using imbNLP.Data.semanticLexicon.procedures;
    using imbNLP.Data.semanticLexicon.term;
    using imbSCI.Core.extensions.io;
    using imbSCI.Core.extensions.text;
    using imbSCI.Core.files.folders;
    using imbSCI.Core.files.unit;
    using imbSCI.Core.reporting;
    using imbSCI.Data;
    using imbSCI.Data.collection.nested;
    using imbSCI.Data.data;
    using imbSCI.Data.enums.reporting;
    using imbSCI.DataComplex.extensions.data.formats;
    using imbSCI.DataComplex.extensions.text;
    using imbSCI.DataComplex.special;
    using imbSCI.Core.files.search;

    public class lexiconSourceFileList:List<lexiconSourceFile>
    {

        /// <summary>
        /// Returns list of files missing
        /// </summary>
        /// <returns></returns>
        public List<string> checkMissingFiles()
        {
            List<string> output = new List<string>();
            foreach (lexiconSourceFile src in this)
            {
                if (!File.Exists(src.filepath))
                {
                    output.Add(src.filepath);
                }
            }
            return output;
        }

        public string getFilePath(lexiconSourceTypeEnum source)
        {

            return getFilePaths(source).First();
        }

        public List<string> getFilePaths(lexiconSourceTypeEnum source)
        {
            List<string> output = new List<string>();

            foreach (lexiconSourceFile item in this)
            {
                if (source.HasFlag(item.sourceType))
                {
                    output.Add(item.filepath);
                }
            }

            return output;
        }

        public void setDefaults()
        {
            Clear();
            Add(lexiconSourceTypeEnum.apertium, "resources\\apertium_hbs.dix");
            Add(lexiconSourceTypeEnum.serbianWordNet, "resources\\sr_wordnet.csv");
            Add(lexiconSourceTypeEnum.englishWordNet, "resources\\wordnet_eng.xlsx");
            Add(lexiconSourceTypeEnum.unitexDelaf, "resources\\unitex_delaf_sr.inf");
            Add(lexiconSourceTypeEnum.unitexDelas, "resources\\unitex_delacf_sr.inf");
            Add(lexiconSourceTypeEnum.unitexDelafBig, "resources\\unitex_delaf.dic");
            Add(lexiconSourceTypeEnum.unitexDelasBig, "resources\\unitex_delacf.dic");
            Add(lexiconSourceTypeEnum.unitexImmutableBig, "resources\\unitex_delaf_immutable.dic");
            Add(lexiconSourceTypeEnum.dictionary, "resources\\recnik_source.csv");
            Add(lexiconSourceTypeEnum.corpus, "resources\\corpus\\sm_corpus_input.csv");
            Add(lexiconSourceTypeEnum.domainConcepts, "resources\\LexiconConcepts.xlsx");
        }

        /// <summary>
        /// Gets the file search operter instance
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        public fileTextOperater getOperater(lexiconSourceTypeEnum source)
        {
            lexiconSourceFile sourceFile = this.First(x => x.sourceType == source);
            fileTextOperater output = new fileTextOperater(sourceFile.filepath);

            return output;
        }
        
        //public DataTable getDataTable(lexiconSourceTypeEnum source)
        //{
        //    lexiconSourceFile sourceFile = this.First(x => x.sourceType == source);
        //    dataTableExportEnum format = sourceFile.filepath.getExportFormatByExtension();

        //    DataTable output = sourceFile.deserialize



           
        //}

        public void Add(lexiconSourceTypeEnum type, string filepath)
        {
            lexiconSourceFile sfile = new lexiconSourceFile();
            sfile.sourceType = type;
            sfile.filepath = filepath;
            Add(sfile);
        }

        public lexiconSourceFileList()
        {

        }
    }

}