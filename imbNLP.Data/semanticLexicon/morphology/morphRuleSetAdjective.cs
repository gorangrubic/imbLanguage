// --------------------------------------------------------------------------------------------------------------------
// <copyright file="morphRuleSetAdjective.cs" company="imbVeles" >
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
namespace imbNLP.Data.semanticLexicon.morphology
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
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
    using imbNLP.Data.semanticLexicon.posCase;
    using imbNLP.Data.semanticLexicon.procedures;
    using imbNLP.Data.semanticLexicon.source;
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

    public class morphRuleSetAdjective :morphRuleSet
    {
        public morphRuleSetAdjective() : base()
        {
        }

        public override void SetRules(params Enum[] gramEnums)
        {
            type = pos_type.A;

            Add("i", new gramFlags(new Enum[] { pos_gender.m, pos_number.s, pos_gramaticalCase.nominativ, pos_degree.a }));
            Add("og", new gramFlags(new Enum[] { pos_gender.m, pos_number.s, pos_gramaticalCase.genitiv, pos_degree.a }));
            Add("om", new gramFlags(new Enum[] { pos_gender.m, pos_number.s, pos_gramaticalCase.dativ, pos_degree.a }));
            Add("i", new gramFlags(new Enum[] { pos_gender.m, pos_number.s, pos_gramaticalCase.akuzativ, pos_degree.a }));
            Add("im", new gramFlags(new Enum[] { pos_gender.m, pos_number.s, pos_gramaticalCase.instrumental, pos_degree.a }));
            Add("i", new gramFlags(new Enum[] { pos_gender.m, pos_number.s, pos_gramaticalCase.vokativ, pos_degree.a }));
            Add("om", new gramFlags(new Enum[] { pos_gender.m, pos_number.s, pos_gramaticalCase.lokativ, pos_degree.a }));
            
            Add("o", new gramFlags(new Enum[] { pos_gender.n, pos_number.s, pos_gramaticalCase.nominativ, pos_degree.a }));
            Add("og", new gramFlags(new Enum[] { pos_gender.n, pos_number.s, pos_gramaticalCase.genitiv, pos_degree.a }));
            Add("om", new gramFlags(new Enum[] { pos_gender.n, pos_number.s, pos_gramaticalCase.dativ, pos_degree.a }));
            Add("o", new gramFlags(new Enum[] { pos_gender.n, pos_number.s, pos_gramaticalCase.akuzativ, pos_degree.a }));
            Add("im", new gramFlags(new Enum[] { pos_gender.n, pos_number.s, pos_gramaticalCase.instrumental, pos_degree.a }));
            Add("o", new gramFlags(new Enum[] { pos_gender.n, pos_number.s, pos_gramaticalCase.vokativ, pos_degree.a }));
            Add("om", new gramFlags(new Enum[] { pos_gender.n, pos_number.s, pos_gramaticalCase.lokativ, pos_degree.a }));

            Add("a", new gramFlags(new Enum[] { pos_gender.f, pos_number.s, pos_gramaticalCase.nominativ, pos_degree.a }));
            Add("e", new gramFlags(new Enum[] { pos_gender.f, pos_number.s, pos_gramaticalCase.genitiv, pos_degree.a }));
            Add("oj", new gramFlags(new Enum[] { pos_gender.f, pos_number.s, pos_gramaticalCase.dativ, pos_degree.a }));
            Add("u", new gramFlags(new Enum[] { pos_gender.f, pos_number.s, pos_gramaticalCase.akuzativ, pos_degree.a }));
            Add("om", new gramFlags(new Enum[] { pos_gender.f, pos_number.s, pos_gramaticalCase.instrumental, pos_degree.a }));
            Add("a", new gramFlags(new Enum[] { pos_gender.f, pos_number.s, pos_gramaticalCase.vokativ, pos_degree.a }));
            Add("oj", new gramFlags(new Enum[] { pos_gender.f, pos_number.s, pos_gramaticalCase.lokativ, pos_degree.a }));


            Add("i", new gramFlags(new Enum[] { pos_gender.m, pos_number.p, pos_gramaticalCase.nominativ, pos_degree.a }));
            Add("ih", new gramFlags(new Enum[] { pos_gender.m, pos_number.p, pos_gramaticalCase.genitiv, pos_degree.a }));
            Add("im", new gramFlags(new Enum[] { pos_gender.m, pos_number.p, pos_gramaticalCase.dativ, pos_degree.a }));
            Add("e", new gramFlags(new Enum[] { pos_gender.m, pos_number.p, pos_gramaticalCase.akuzativ, pos_degree.a }));
            Add("im", new gramFlags(new Enum[] { pos_gender.m, pos_number.p, pos_gramaticalCase.instrumental, pos_degree.a }));
            Add("i", new gramFlags(new Enum[] { pos_gender.m, pos_number.p, pos_gramaticalCase.vokativ, pos_degree.a }));
            Add("im", new gramFlags(new Enum[] { pos_gender.m, pos_number.p, pos_gramaticalCase.lokativ, pos_degree.a }));

            Add("a", new gramFlags(new Enum[] { pos_gender.n, pos_number.p, pos_gramaticalCase.nominativ, pos_degree.a }));
            Add("e", new gramFlags(new Enum[] { pos_gender.n, pos_number.p, pos_gramaticalCase.genitiv, pos_degree.a }));
            Add("oj", new gramFlags(new Enum[] { pos_gender.n, pos_number.p, pos_gramaticalCase.dativ, pos_degree.a }));
            Add("oj", new gramFlags(new Enum[] { pos_gender.n, pos_number.p, pos_gramaticalCase.akuzativ, pos_degree.a }));
            Add("om", new gramFlags(new Enum[] { pos_gender.n, pos_number.p, pos_gramaticalCase.instrumental, pos_degree.a }));
            Add("a", new gramFlags(new Enum[] { pos_gender.n, pos_number.p, pos_gramaticalCase.vokativ, pos_degree.a }));
            Add("oj", new gramFlags(new Enum[] { pos_gender.n, pos_number.p, pos_gramaticalCase.lokativ, pos_degree.a }));

            Add("e", new gramFlags(new Enum[] { pos_gender.f, pos_number.p, pos_gramaticalCase.nominativ, pos_degree.a }));
            Add("ih", new gramFlags(new Enum[] { pos_gender.f, pos_number.p, pos_gramaticalCase.genitiv, pos_degree.a }));
            Add("im", new gramFlags(new Enum[] { pos_gender.f, pos_number.p, pos_gramaticalCase.dativ, pos_degree.a }));
            Add("e", new gramFlags(new Enum[] { pos_gender.f, pos_number.p, pos_gramaticalCase.akuzativ, pos_degree.a }));
            Add("im", new gramFlags(new Enum[] { pos_gender.f, pos_number.p, pos_gramaticalCase.instrumental, pos_degree.a }));
            Add("e", new gramFlags(new Enum[] { pos_gender.f, pos_number.p, pos_gramaticalCase.vokativ, pos_degree.a }));
            Add("im", new gramFlags(new Enum[] { pos_gender.f, pos_number.p, pos_gramaticalCase.lokativ, pos_degree.a }));

            
        }
    }

}