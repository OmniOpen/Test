//  Copyright (C) 2014 Jerome Bell (jeromebell0509@gmail.com)
//
//  This file is part of OmniOpen Test.
//  OmniOpen Test is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  OmniOpen Test is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with OmniOpen Test.  If not, see <http://www.gnu.org/licenses/>.
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OmniOpen.Test.Test.Unit.Helpers
{
    [TestClass]
    class ClassWithProtectedInternalTestContextProperty
    {
        protected internal TestContext TestContext { get; set; }
    }
}
