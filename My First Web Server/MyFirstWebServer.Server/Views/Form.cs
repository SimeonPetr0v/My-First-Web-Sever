using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstWebServer.Server.Views
{
    public static class Form
    {
        public const string HTML = @"<form action='/login' method='POST'>
            Name: <input type='text' name='Name'/>
            Age: <input type='number' name='Age'/>
            <input type='submit' value='Save' />
        </form>";
    }
}

