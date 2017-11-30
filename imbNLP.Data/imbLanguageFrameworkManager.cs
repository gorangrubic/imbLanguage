// --------------------------------------------------------------------------------------------------------------------
// <copyright file="imbLanguageFrameworkManager.cs" company="imbVeles" >
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
namespace imbNLP.Data
{
    #region imbVELES USING

    using System;
    using System.IO;
    using imbNLP.Data.basic;
    using imbSCI.Data.collection.nested;
    using imbACE.Core.core;
    using imbSCI.Data.enums;
    using imbNLP.Data.extended.dict.core;
    using imbSCI.Data;
    using imbSCI.Core.extensions.text;
    using imbNLP.Data.extended;
    using imbACE.Core.core.exceptions;
    using imbNLP.Data.extended.apertium;
    using imbNLP.Data.extended.unitex;
    using imbNLP.Data.extended.wordnet;
    using imbNLP.Data.extended.namedEntities;

    //using imbCore.data.collection.nested;

    #endregion

    /// <summary>
    /// Manager klasa treba da omoguci referenciranje i upravljanje statickim resursima
    /// </summary>
    public static class imbLanguageFrameworkManager
    {



        private static imbCollectionNestedEnumToString<basicLanguageEnum, basicLanguageParameterEnum> _languageDataSet;
        /// <summary>
        /// static and autoinitiated object
        /// </summary>
        public static imbCollectionNestedEnumToString<basicLanguageEnum, basicLanguageParameterEnum> languageDataSet
        {
            get
            {
                if (_languageDataSet == null)
                {
                    _languageDataSet = new imbCollectionNestedEnumToString<basicLanguageEnum, basicLanguageParameterEnum>();

                    _languageDataSet[basicLanguageEnum.english][basicLanguageParameterEnum.affixPath] = "resources\\hunspell\\en-US.aff";
                    _languageDataSet[basicLanguageEnum.english][basicLanguageParameterEnum.dictPath] = "resources\\hunspell\\en-US.dic";
                    _languageDataSet[basicLanguageEnum.english][basicLanguageParameterEnum.englishName] = "English";
                    _languageDataSet[basicLanguageEnum.english][basicLanguageParameterEnum.iso2code] = "en";
                    _languageDataSet[basicLanguageEnum.english][basicLanguageParameterEnum.nativeName] = "English";
                    _languageDataSet[basicLanguageEnum.english][basicLanguageParameterEnum.needles] = "en,eng,gb,gbr,uk,engleski,english";

                    _languageDataSet[basicLanguageEnum.german][basicLanguageParameterEnum.affixPath] = "resources\\hunspell\\de_DE_frami.aff";
                    _languageDataSet[basicLanguageEnum.german][basicLanguageParameterEnum.dictPath] = "resources\\hunspell\\de_DE_frami.dic";
                    _languageDataSet[basicLanguageEnum.german][basicLanguageParameterEnum.englishName] = "German";
                    _languageDataSet[basicLanguageEnum.german][basicLanguageParameterEnum.iso2code] = "de";
                    _languageDataSet[basicLanguageEnum.german][basicLanguageParameterEnum.nativeName] = "Deutsch";
                    _languageDataSet[basicLanguageEnum.german][basicLanguageParameterEnum.needles] = "de,ger,nem,deutsch,german,deu,nemacki,nemački";

                    _languageDataSet[basicLanguageEnum.italian][basicLanguageParameterEnum.affixPath] = "resources\\hunspell\\it_IT.aff";
                    _languageDataSet[basicLanguageEnum.italian][basicLanguageParameterEnum.dictPath] = "resources\\hunspell\\it_IT.dic";
                    _languageDataSet[basicLanguageEnum.italian][basicLanguageParameterEnum.englishName] = "Italian";
                    _languageDataSet[basicLanguageEnum.italian][basicLanguageParameterEnum.iso2code] = "it";
                    _languageDataSet[basicLanguageEnum.italian][basicLanguageParameterEnum.nativeName] = "Italiano";
                    _languageDataSet[basicLanguageEnum.italian][basicLanguageParameterEnum.needles] = "it,ita,italian,italiano,italijanski";

                    _languageDataSet[basicLanguageEnum.russian][basicLanguageParameterEnum.affixPath] = "resources\\hunspell\\ru_RU.aff";
                    _languageDataSet[basicLanguageEnum.russian][basicLanguageParameterEnum.dictPath] = "resources\\hunspell\\ru_RU.dic";
                    _languageDataSet[basicLanguageEnum.russian][basicLanguageParameterEnum.englishName] = "Russian";
                    _languageDataSet[basicLanguageEnum.russian][basicLanguageParameterEnum.iso2code] = "ru";
                    _languageDataSet[basicLanguageEnum.russian][basicLanguageParameterEnum.nativeName] = "Russky";
                    _languageDataSet[basicLanguageEnum.russian][basicLanguageParameterEnum.needles] = "ru,rus,russkiy,ruski,russian";

                    _languageDataSet[basicLanguageEnum.serbian][basicLanguageParameterEnum.affixPath] = "resources\\hunspell\\sr-Latn.aff";
                    _languageDataSet[basicLanguageEnum.serbian][basicLanguageParameterEnum.dictPath] = "resources\\hunspell\\sr-Latn.dic";
                    _languageDataSet[basicLanguageEnum.serbian][basicLanguageParameterEnum.englishName] = "Serbian";
                    _languageDataSet[basicLanguageEnum.serbian][basicLanguageParameterEnum.iso2code] = "sr";
                    _languageDataSet[basicLanguageEnum.serbian][basicLanguageParameterEnum.nativeName] = "Srpski";
                    _languageDataSet[basicLanguageEnum.serbian][basicLanguageParameterEnum.needles] = "sr,srp,rs,srb,srpski,serbian,yu";

                    _languageDataSet[basicLanguageEnum.serbianCyr][basicLanguageParameterEnum.affixPath] = "resources\\hunspell\\sr.aff";
                    _languageDataSet[basicLanguageEnum.serbianCyr][basicLanguageParameterEnum.dictPath] = "resources\\hunspell\\sr.dic";
                    _languageDataSet[basicLanguageEnum.serbianCyr][basicLanguageParameterEnum.englishName] = "Serbian";
                    _languageDataSet[basicLanguageEnum.serbianCyr][basicLanguageParameterEnum.iso2code] = "sr";
                    _languageDataSet[basicLanguageEnum.serbianCyr][basicLanguageParameterEnum.nativeName] = "Srpski";
                    _languageDataSet[basicLanguageEnum.serbianCyr][basicLanguageParameterEnum.needles] = "sr,srp,rs,srb,srpski,serbian,yu";

                    _languageDataSet[basicLanguageEnum.slovenian][basicLanguageParameterEnum.affixPath] = "resources\\hunspell\\sl_SI.aff";
                    _languageDataSet[basicLanguageEnum.slovenian][basicLanguageParameterEnum.dictPath] = "resources\\hunspell\\sl_SI.dic";
                    _languageDataSet[basicLanguageEnum.slovenian][basicLanguageParameterEnum.englishName] = "Slovenian";
                    _languageDataSet[basicLanguageEnum.slovenian][basicLanguageParameterEnum.iso2code] = "si";
                    _languageDataSet[basicLanguageEnum.slovenian][basicLanguageParameterEnum.nativeName] = "Slovenski";
                    _languageDataSet[basicLanguageEnum.slovenian][basicLanguageParameterEnum.needles] = "si,sl,slovenian,slo,slovenački,slovenacki,slovenski";
                }
                return _languageDataSet;
            }
        }

        /// <summary>
        /// Returns a basic language object with loaded dictionary file
        /// </summary>
        /// <param name="languageID">The language identifier.</param>
        /// <returns></returns>
        public static basicLanguage GetBasicLanguage(basicLanguageEnum languageID)
        {
            basicLanguage language = new basicLanguage();
            language.affixFilePath = languageDataSet[languageID][basicLanguageParameterEnum.affixPath];
            language.dictFilePath = languageDataSet[languageID][basicLanguageParameterEnum.dictPath];
            language.languageNativeName = languageDataSet[languageID][basicLanguageParameterEnum.nativeName];
            language.languageEnglishName = languageDataSet[languageID][basicLanguageParameterEnum.englishName];
            language.iso2Code = languageDataSet[languageID][basicLanguageParameterEnum.iso2code];
            language.langIDNeedles.AddRange(languageDataSet[languageID][basicLanguageParameterEnum.needles].Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries));
            language.checkHuspell(true);

            return language;
        }



        private static builderForLog _log = new builderForLog(logOutputSpecial.languageEngine);
        /// <summary>
        ///
        /// </summary>
        public static builderForLog log
        {
            get
            {
                if (_log == null) _log = new builderForLog();
                return _log;
            }
        }



        #region --- serbian ------- Extended language instanca sa default sadrzajem

        private static extendedLanguage _serbian = new extendedLanguage();
        /// <summary>
        /// Extended language instanca sa default sadrzajem
        /// </summary>
        public static extendedLanguage serbian
        {
            get
            {
                
                return _serbian;
            }
            set
            {
                _serbian = value;
            }
        }
        #endregion



        private static extendedLanguage _english;
        /// <summary>
        ///
        /// </summary>
        public static extendedLanguage english
        {
            get
            {
                return _english;
            }
            set
            {
                _english = value;
            }
        }



        public static tokenQuery exploreToken(string token, object metaobject, tokenQuerySourceEnum sources)
        {
            log.log("Token [" + token + "] asks to be explored with [" + sources.ToStringEnumSmart() + "]"); //000 ToString())
            tokenQuery query = new tokenQuery(token, metaobject, sources);
            
            var srl = sources.getEnumListFromFlags<tokenQuerySourceEnum>();

            foreach (tokenQuerySourceEnum source in srl)
            {
                tokenQueryResponse response = null;
                switch (source)
                {
                    case tokenQuerySourceEnum.imb_alfabetTest:
                        response = languageManagerAlphabet.manager.exploreToken(query);
                        break;
                    case tokenQuerySourceEnum.hunspell:
                        response = languageManagerHunspell.manager.exploreToken(query);
                        break;
                    case tokenQuerySourceEnum.imb_namedentities:
                        response = languageManagerHunspell.manager.exploreToken(query);
                        break;
                    case tokenQuerySourceEnum.imb_elements:
                        response = languageManagerHunspell.manager.exploreToken(query);
                        break;
                    case tokenQuerySourceEnum.imb_dictionary:
                        response = languageManagerHunspell.manager.exploreToken(query);
                        break;
                    case tokenQuerySourceEnum.imb_lexicon:
                        response = languageManagerHunspell.manager.exploreToken(query);
                        break;
                    case tokenQuerySourceEnum.ext_wordnet:
                        response = languageManagerHunspell.manager.exploreToken(query);
                        break;
                    case tokenQuerySourceEnum.ext_unitex:
                        response = languageManagerHunspell.manager.exploreToken(query);
                        break;
                    case tokenQuerySourceEnum.ext_dict:
                        response = languageManagerHunspell.manager.exploreToken(query);
                        break;
                    case tokenQuerySourceEnum.imb_morphology:
                        break;


                }
                if (response.status == tokenQueryResultEnum.dismiss) break;
            }
            return query;
        }


        private static bool getLanguageFailed = false;


        public const string PATH_hunspell_dict = "resources\\hunspell\\sr-Latn.dic";
        public const string PATH_hunspell_aff = "resources\\hunspell\\sr-Latn.aff";

        public const string PATH_hunspell_dict_en = "resources\\hunspell\\en-US.dic";
        public const string PATH_hunspell_aff_en = "resources\\hunspell\\en-US.aff";
        /// <summary>
        /// staticka kolekcija basicLanguage objekata
        /// </summary>
        //  public static basicLanguageCollection languages;
        public static basicLanguage getLanguage(string iso2code)
        {
            if (serbian == null)
            {
                serbian = new extendedLanguage();
                
                if (!File.Exists(PATH_hunspell_aff)) throw new aceGeneralException("Hunspell AFF file missing!");
                if (!File.Exists(PATH_hunspell_dict)) throw new aceGeneralException("Hunspell DICT file missing!");

                basicLanguage language = new basicLanguage();
                language.affixFilePath = PATH_hunspell_aff;
                language.dictFilePath = PATH_hunspell_dict;
                language.languageNativeName = "Srpski";
                language.languageEnglishName = "Serbian";
                language.iso2Code = "sr";
                serbian.basic = language;
                
                if (language.checkHuspell(true))
                {

                }
                else
                {

                }
            }
            return serbian.basic;


            //// < ---- override

            //String query = "iso2Code='{0}'".FormatWith(iso2code);
            //basicLanguage language = new basicLanguage();
            //try
            //{
            //    Int32 i = languages.loadItems(true, 10, 0, System.Data.LoadOption.OverwriteChanges);
            //    var lang = languages.selectItems<basicLanguage>(query, 1).First();
            //    if (i > 0)
            //    {
            //        // // languages.instances.FirstOrDefault(x => x.iso2Code == iso2code);
            //        if (lang != null)
            //        {
            //            return lang;
            //        } else
            //        {
            //            return serbian.basic;
            //        }
            //    } else
            //    {
            //        return serbian.basic;
            //    }
                
            //    //.selectItems<basicLanguage>(query, 1).First<basicLanguage>();

            //} catch (Exception ex)
            //{
            //    if (getLanguageFailed) throw new aceGeneralException("Language selection failed second time", ex, serbian, "Language database never loaded");
            //    getLanguageFailed = true;
            //    log.log("Language database not ready --> loading Serbian as default.");
            //    return serbian.basic;
            //}
            


            ////      imbLanguageFramework.imbLanguageFrameworkManager.languages.selectItemByUnique(AgentSettings.languageIsoCode) as basicLanguage;

            //if (language == null)
            //{
            //    String msg = "Basic language definition for [" + iso2code +
            //                 "] not found in the global languages collection (" +
            //                 imbLanguageFramework.imbLanguageFrameworkManager.languages.Count + ")";
            //    logSystem.log(msg, logType.FatalError, true);
            //    throw new aceGeneralException("Language init failed");
            //}

            //return language;
        }

        /// <summary>
        /// 2013C: Ovo je bitno da bude pozvano kako bi uspesno referencirao ovu Biblioteku!! -- > TREBA DA GA POZOVE manager.onApplicationReady() 
        /// </summary>
        public static void Prepare()
        {
            aceLog.consoleControl.setAsOutput(log, "lang_mng");

            //basicLanguageCollection.isReadyGlobal = true;

            //  Int32 ln = languages.loadItems(false, 5);
            //  log.log("Hunspell language definitions loaded [" + ln + "]");

            if (_serbian == null)
            {
                _serbian = new extendedLanguage();
                
               // _serbian.morphologies_verbs.buildDefaultItem();
               // _serbian.morphologies_nouns.buildDefaultItem();

                

                if (!File.Exists(PATH_hunspell_aff)) throw new aceGeneralException("Hunspell AFF file missing!");
                if (!File.Exists(PATH_hunspell_dict)) throw new aceGeneralException("Hunspell DICT file missing!");

                basicLanguage language = new basicLanguage();
                language.affixFilePath = PATH_hunspell_aff;
                language.dictFilePath = PATH_hunspell_dict;
                language.languageNativeName = "Srpski";
                language.languageEnglishName = "Serbian";
                language.iso2Code = "sr";
                
                _serbian.basic = language;

                if (language.checkHuspell(true))
                {
                    log.log("Hunspell language module: " + language.languageEnglishName + " ready");
                }
                else
                {
                    aceGeneralException axe = new aceGeneralException("Serbian language Hunspell module failed", null, english, "Serbian Hunspell failed");
                    throw axe;
                }


                _serbian.basic = language;
                _serbian.loadAlfabet("extended\\alfabet.txt");
            }

            if (_english == null)
            {
                _english = new extendedLanguage
                {
                    basic = new basicLanguage("en")
                };
                _english.basic.affixFilePath = PATH_hunspell_aff_en;
                _english.basic.dictFilePath = PATH_hunspell_dict_en;
                _english.basic.languageNativeName = "Engleski";
                _english.basic.languageEnglishName = "English";
                _english.basic.iso2Code = "en";

                if (_english.basic.checkHuspell(true))
                {
                    log.log("Hunspell language module: " + _english.basic.languageEnglishName + " ready");
                }
                else
                {
                    aceGeneralException axe = new aceGeneralException("English language Hunspell module failed", null, english, "English Hunspell failed");
                    throw axe;
                }
            }


            //languages.loadItems(false, -1, 0, System.Data.LoadOption.OverwriteChanges);

            //dictionaryManager.prepare();
            //elementsManager.prepare();

            languageManagerApertium.manager.prepare();

            languageManagerAlphabet.manager.prepare();
          //  languageManagerDictionary.manager.prepare();
          //  languageManagerElements.manager.prepare();

            languageManagerHunspell.manager.prepare();

          //  languageManagerLexicon.manager.prepare();
           // languageManagerMorphology.manager.prepare();

            languageManagerUnitex.manager.prepare();

            languageManagerWordnet.manager.prepare();
           // languageManagerDict.manager.prepare();

            languageManagerDBNamedEntities.manager.prepare();

            semanticLexicon.semanticLexiconManager.manager.prepare();


            if (serbian.basic.hunspellEngine.Spell("Proba"))
            {
                log.log("Hunspell language module: " + serbian.basic.languageEnglishName + " Spell check working");
            }


            if (english.basic.hunspellEngine.Spell("Test"))
            {
                log.log("Hunspell language module: " + english.basic.languageEnglishName + " Spell check working");
            }

            aceLog.consoleControl.removeFromOutput(log);
        }

        #region --- languages ------- static and autoinitiated object

        /// <summary>
        /// static and autoinitiated object
        /// </summary>
        public static basicLanguageCollection languages { get; set; } = new basicLanguageCollection();

        #endregion
    }
}