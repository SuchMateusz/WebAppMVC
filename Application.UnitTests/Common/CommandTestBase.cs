﻿using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppMVC.Infrastructure;

namespace Application.UnitTests.Common
{
    public class CommandTestBase : IDisposable
    {
        protected readonly Context _context;
        protected readonly Mock<Context> _contextMock;

        public CommandTestBase()
        {
            _contextMock = DbContextFactory.Create();
            _context = _contextMock.Object;
        }

        public void Dispose()
        {
            DbContextFactory.Destroy(_context);
        }
    }
}
