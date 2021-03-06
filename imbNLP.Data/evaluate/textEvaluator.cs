// --------------------------------------------------------------------------------------------------------------------
// <copyright file="textEvaluator.cs" company="imbVeles" >
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
namespace imbNLP.Data.evaluate
{
    using System.Collections.Generic;
    using imbNLP.Data.basic;
    using imbNLP.Data.semanticLexicon;
    using imbSCI.Data.data;

    public class textEvaluator:imbBindable
    {
        public basicLanguage languageA { get; protected set; } = imbLanguageFrameworkManager.serbian.basic;
        public basicLanguage languageB { get; protected set; } = imbLanguageFrameworkManager.english.basic;


        public textEvaluator(semanticLexiconManager __manager)
        {
            manager = __manager;
        }

        public textEvaluation evaluate(string input)
        {
            textEvaluation output = new textEvaluation(this, input);
            return output;
        }

        public semanticLexiconManager manager { get; protected set; }

        public List<string> langATokens { get; protected set; } = new List<string>();

        public List<string> langBTokens { get; protected set; } = new List<string>();

        public List<string> langABTokens { get; protected set; } = new List<string>();

        public List<string> langNotABTokens { get; protected set; } = new List<string>();


    }

}