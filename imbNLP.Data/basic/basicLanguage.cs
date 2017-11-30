// --------------------------------------------------------------------------------------------------------------------
// <copyright file="basicLanguage.cs" company="imbVeles" >
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
namespace imbNLP.Data.basic
{
    #region imbVELES USING

    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Xml.Serialization;
    
    using imbACE.Core.core.exceptions;
    using imbSCI.Data.data;
    using NHunspell;
    using imbNLP.Data.basic.enums;

    // using aceCommonTypes.reporting;

    #endregion

    /// <summary>
    /// 2014c> Entity item basicLanguage, part of basicLanguageCollection
    /// </summary>

    public class basicLanguage : imbBindable
    {

        public List<string> langIDNeedles { get; set; } = new List<string>();

        public basicLanguage()
        {
            iso2Code = "sr";
        }

        public basicLanguage(string __iso2Code)
        {
            iso2Code = __iso2Code;
        }

        /// <summary>
        /// Proverava da li je rec poznata - tj. sadrzana u recniku
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public virtual bool isKnownWord(string input)
        {
            return basicKnownWordTest(input);
        }

        protected bool basicKnownWordTest(string input)
        {
            if (hunspellEngine == null)
            {


                var ex = new aceGeneralException("hunspellEngine not ready at basic language object", null, this, "Hunspell:" + languageEnglishName + " not ready");
                throw ex;
                //devNoteManager.note(this, ex, isb.ToString(), "basicLanguage", devNoteType.nlp);

                return false;
            }
            return hunspellEngine.Spell(input);
        }

        /*
        /// <summary>
        /// Priprema Hunspell engine i ostale privremene podatke
        /// </summary>
        public void prepareHunspellEngine()
        {
            diagnosticReport = "";

            if (_hunspellEngine == null)
            {

                if ((hunspellAffixStream != null) && (hunspellDictStream != null))
                {
                    try
                    {
                        _hunspellEngine = new Hunspell(hunspellAffixStream, hunspellDictStream);
                    }
                    catch (Exception ex)
                    {
                        diagnosticReport += "Hunspell error: " + ex.Message + Environment.NewLine;
                        logSystem.log("Hunspell error: " + ex.Message, logType.Warning);
                    }
                }
                else
                {
                    diagnosticReport += "Affix / Dict streams not ready" + Environment.NewLine;
                }
            }
        }
        */

        //public bool checkDictFile(bool allowSetup = true, bool forceSelect = false)
        //{
        //    bool output = true;
        //    dialogPolicy dp = dialogPolicy.openIfNeeded;
        //    if (!allowSetup) dp = dialogPolicy.disableDialog;
        //    if (hunspellDictStream == null)
        //    {
        //        basicLanguageFileIO.loadFromFile(this, basicLanguageFileFormatType.huspellDict, dp, dictFilePath);
        //    }
        //    return output;
        //}


        ///// <summary>
        ///// Poziva na selektovanje potrebnog fajla
        ///// </summary>
        ///// <param name="fileFormat"></param>
        ///// <returns></returns>
        //public string selectFilePath(basicLanguageFileFormatType fileFormat)
        //{
        //    string pt = "";
        //    switch (fileFormat)
        //    {
        //        case basicLanguageFileFormatType.huspellAffix:
        //            pt = affixFilePath;
        //            break;
        //        case basicLanguageFileFormatType.huspellDict:
        //            pt = dictFilePath;
        //            break;
        //    }
        //    pt =
        //        @select.selectFile(fileFormat, pt, imbCore.environment.files.enums.dialogPolicy.forceDialog).relatedPath;

        //    if (!string.IsNullOrEmpty(pt))
        //    {
        //        switch (fileFormat)
        //        {
        //            case basicLanguageFileFormatType.huspellAffix:
        //                affixFilePath = pt;
        //                checkAiffFile(false);
        //                break;
        //            case basicLanguageFileFormatType.huspellDict:
        //                dictFilePath = pt;
        //                checkDictFile(false);
        //                break;
        //        }
        //    }
        //    return pt;
        //}

        //private bool checkAiffFile(bool allowSetup = true)
        //{
        //    bool output = true;
        //    dialogPolicy dp = dialogPolicy.openIfNeeded;
        //    if (!allowSetup) dp = dialogPolicy.disableDialog;

        //    if (hunspellAffixStream == null)
        //    {
        //        basicLanguageFileIO.loadFromFile(this, basicLanguageFileFormatType.huspellAffix, dp, affixFilePath);
        //    }
        //    return output;
        //}


        /// <summary>
        /// Static method extension
        /// </summary>
        public bool checkHuspell(bool allowSetup = true)
        {
            bool output; // = new Boolean();   
            
            
            bool change = false;
            
            try
            {
                if (hunspellEngine == null)
                {
                   // hunspellEngine = new Hunspell(imbLanguageFrameworkManager.PATH_hunspell_aff, imbLanguageFrameworkManager.PATH_hunspell_dict);
                   // hunspellHypen = new Hyphen(imbLanguageFrameworkManager.PATH_hunspell_dict); // NHunspell.Hyphen(hunspellDictStream);

                    hunspellEngine = new Hunspell(affixFilePath, dictFilePath);
                    hunspellHypen = new Hyphen(affixFilePath); // NHunspell.Hyphen(hunspellDictStream);

                    imbLanguageFrameworkManager.log.log("Affix file: " + affixFilePath);
                    imbLanguageFrameworkManager.log.log("Dict file: " + dictFilePath);

                    change = true;
                }
            }
            catch (Exception ex)
            {
                //logSystem.log("Engine init failed : " + ex.Message + " for model: " + iso2Code,
                            //  logType.CriticalWarning, true);
                throw new aceGeneralException("checkHuspellFailed", ex, this, "Huspell check failed");

                return false;
            }

            try
            {
                if (hunspellHypen == null)
                {
 
                    hunspellHypen = new Hyphen(imbLanguageFrameworkManager.PATH_hunspell_dict); // NHunspell.Hyphen(hunspellDictStream);
                    change = true;
                }
            }
            catch (Exception ex)
            {
                //logSystem.log("Engine init failed : " + ex.Message + " for model: " + iso2Code,
                //  logType.CriticalWarning, true);
                throw new aceGeneralException("hunspellHypen", ex, this, "Huspell check failed");

                return false;
            }

            //if (change)
            //{
            //    setModified();

            //    if (hunspellEngine != null)
            //    {
            //        if (parent != null)
            //        {
            //           // parent.execute(imbSqlEntityCollectionOperation.saveChanges);
            //        }
            //        else
            //        {
            //           // imbLanguageFrameworkManager.languages.execute(imbSqlEntityCollectionOperation.saveChanges);
            //        }
            //    }
            //}
            //saveItem(false);

            return (hunspellEngine != null);
        }

        #region -----------  hunspellFactory  -------  [Sve opcije Hunspell biblioteke]

        private SpellFactory _hunspellFactory; // = new  SpellFactory();

        /// <summary>
        /// Sve opcije Hunspell biblioteke
        /// </summary>
        [XmlIgnore]
        [Category("Misc")]
       
        [DisplayName("hunspellFactory")]
        [Description("Sve opcije Hunspell biblioteke")]
        internal SpellFactory hunspellFactory
        {
            get { return _hunspellFactory; }
            set
            {
                _hunspellFactory = value;
                OnPropertyChanged("hunspellFactory");
            }
        }

        #endregion

        #region -----------  hunspellHypen  -------  [Hypenizator]

        private Hyphen _hunspellHypen; // = new Hyphen();

        /// <summary>
        /// Hypenizator
        /// </summary>
        [XmlIgnore]
        [Category("Misc")]
       
        [DisplayName("hunspellHypen")]
        [Description("Hypenizator")]
        internal Hyphen hunspellHypen
        {
            get { return _hunspellHypen; }
            set
            {
                _hunspellHypen = value;
                OnPropertyChanged("hunspellHypen");
            }
        }

        #endregion

        #region -----------  hunspellEngine  -------  [Objekat prema Hunspell engine-u. Objekat bi trebao da bude instanciran]

        private Hunspell _hunspellEngine; // = new Hunspell();

        /// <summary>
        /// Objekat prema Hunspell engine-u. Objekat bi trebao da bude instanciran
        /// </summary>
        [XmlIgnore]
        [Category("Misc")]
        [DisplayName("hunspellEngine")]
        [Description("Objekat prema Hunspell engine-u. Objekat bi trebao da bude instanciran")]
       
        internal Hunspell hunspellEngine
        {
            get
            {
                //prepareHunspellEngine();

                return _hunspellEngine;
            }
            set
            {
                _hunspellEngine = value;
                OnPropertyChanged("hunspellEngine");
            }
        }

        #endregion

        #region -----------  affixFilePath  -------  [Putanja prema affix fajlu]

        private string _affixFilePath = ""; // = new String();

        /// <summary>
        /// Putanja prema affix fajlu
        /// </summary>
        // [XmlIgnore]
        [Category("extendedLanguage")]
        [DisplayName("affixFilePath")]
        [Description("Putanja prema affix fajlu")]
        //  [imbSql(imbSerializationMode.sqlString)]
            public string affixFilePath
        {
            get
            {
                if (string.IsNullOrEmpty(_affixFilePath))
                    _affixFilePath = "resources\\hunspell\\sr-Latn.aff";
                return _affixFilePath;
            }
            set
            {
                _affixFilePath = value;
                OnPropertyChanged("affixFilePath");
            }
        }

        #endregion

        #region -----------  dictFilePath  -------  [Putanja prema DICT fajlu]

        private string _dictFilePath = ""; // = new String();

        /// <summary>
        /// Putanja prema DICT fajlu
        /// </summary>
        // [XmlIgnore]
        [Category("extendedLanguage")]
        [DisplayName("dictFilePath")]
        [Description("Putanja prema DICT fajlu")]
        //[imbSql(imbSerializationMode.sqlString)]
            public string dictFilePath
        {
            get
            {
                if (string.IsNullOrEmpty(_dictFilePath))
                    _dictFilePath = "resources\\hunspell\\sr-Latn.dic";
                return _dictFilePath;
            }
            set
            {
                _dictFilePath = value;
                OnPropertyChanged("dictFilePath");
            }
        }

        #endregion

        #region -----------  iso2Code  -------  [ISO kodna oznaka jezika]

        private string _iso2Code = "sr"; // = new String();

        /// <summary>
        /// ISO kodna oznaka jezika
        /// </summary>
        // [XmlIgnore]
        [Category("Basic")]
        [DisplayName("iso2Code")]
        [Description("ISO kodna oznaka jezika")]
        public string iso2Code
        {
            get { return _iso2Code; }
            set
            {
                _iso2Code = value;
                OnPropertyChanged("iso2Code");
            }
        }

        #endregion

        #region -----------  languageNativeName  -------  [Naziv na sopstvenom jeziku]

        private string _languageNativeName = "Srpski"; // = new String();

        /// <summary>
        /// Naziv na sopstvenom jeziku
        /// </summary>
        // [XmlIgnore]
        [Category("Basic")]
        [DisplayName("languageNativeName")]
        [Description("Naziv na sopstvenom jeziku")]
     
        public string languageNativeName
        {
            get { return _languageNativeName; }
            set
            {
                _languageNativeName = value;
                OnPropertyChanged("languageNativeName");
            }
        }

        #endregion

        #region -----------  languageEnglishName  -------  [Naziv jezika na engleskom]

        private string _languageEnglishName = "Serbian"; // = new String();

        /// <summary>
        /// Naziv jezika na engleskom
        /// </summary>
        // [XmlIgnore]
        [Category("Basic")]
        [DisplayName("languageEnglishName")]
        [Description("Naziv jezika na engleskom")]
        public string languageEnglishName
        {
            get { return _languageEnglishName; }
            set
            {
                _languageEnglishName = value;
                OnPropertyChanged("languageEnglishName");
            }
        }

        #endregion

        #region -----------  diagnosticReport  -------  [diagnosticki izvestaj]

        private string _diagnosticReport = ""; // = new String();

        /// <summary>
        /// diagnosticki izvestaj
        /// </summary>
        [XmlIgnore]
        [Category("Report")]
        [DisplayName("diagnosticReport")]
        [Description("diagnosticki izvestaj")]
        
        public string diagnosticReport
        {
            get { return _diagnosticReport; }
            set
            {
                _diagnosticReport = value;
                OnPropertyChanged("diagnosticReport");
            }
        }

        #endregion

        #region -----------  hunspellAffixStream  -------  [Hunspell affix fajl stream - serijalizovana verzija Hunspell Afix fajla]

        private byte[] _hunspellAffixStream; // = new String();

        /// <summary>
        /// Hunspell affix fajl stream - serijalizovana verzija Hunspell Afix fajla
        /// </summary>
        [XmlIgnore]
        [Category("Misc")]
        [DisplayName("hunspellAffixStream")]
        [Description("Hunspell affix fajl stream - serijalizovana verzija Hunspell Afix fajla")]
        
        internal byte[] hunspellAffixStream
        {
            get { return _hunspellAffixStream; }
            set
            {
                _hunspellAffixStream = value;
                OnPropertyChanged("hunspellAffixStream");
            }
        }

        #endregion

        #region -----------  hunspellDictStream  -------  [Hunspell dict fajl stream - serijalizovana verzija Hunspell dict fajla]

        private byte[] _hunspellDictStream; // = new String();

        /// <summary>
        /// Hunspell dict fajl stream - serijalizovana verzija Hunspell dict fajla
        /// </summary>
        [XmlIgnore]
        [Category("Misc")]
        [DisplayName("hunspellDictStream")]
        [Description("Hunspell dict fajl stream - serijalizovana verzija Hunspell dict fajla")]
        
        internal byte[] hunspellDictStream
        {
            get { return _hunspellDictStream; }
            set
            {
                _hunspellDictStream = value;
                OnPropertyChanged("hunspellDictStream");
            }
        }

        #endregion
    }
}