using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SciApp.Core.Test
{
    public class PropertyValue<TProperty>
    {
        public TProperty Value { get; set; }
        public TProperty FormulaValue { get; set; }
    }


    public class Credit
    {
        public decimal Fix { get; set; }
        public decimal Percent { get; set; }
    }

    public class GetPropertyTest
    {

        [Test]
        public void Test()
        {

            var fare = 1000;
            var credit = new Credit() { Fix = 5 , Percent =  10};

            var fix = GetPropertyFormula(credit, c => c.Fix, input => input );
            var percent = GetPropertyFormula(credit, c => c.Percent, input => fare * (1 * (input / 100)));

            var allRequiredProperties = new[] {fix, percent};

            var isZero = allRequiredProperties.All(p => p.Value == 0);
            Assert.IsFalse(isZero);
            var totalCharge = allRequiredProperties.Sum(p => p.FormulaValue);
            Assert.AreEqual(5 + 100, totalCharge);

        }

        public PropertyValue<TProperty> GetPropertyFormula<TSource, TProperty>(TSource source,
            Expression<Func<TSource, TProperty>> propertyLambda, Func<TProperty, TProperty> formula)
        {
            var member = propertyLambda.Body as MemberExpression;
            var propInfo = member.Member as PropertyInfo;

            var propertyValue = (TProperty)propInfo.GetValue(source);
            var formulaValue = formula(propertyValue);
            return new PropertyValue<TProperty>() { Value = propertyValue, FormulaValue = formulaValue };

        }

        [Test]
        public void TestTree()
        {
            Expression<Func<string, bool>> f = s => s.Length < 5;

            var right = ((BinaryExpression)f.Body).Right;

            Console.WriteLine($"nodeType {right.NodeType}");
            var node = (ConstantExpression)right;
            Assert.AreEqual(5, node.Value);


            var left = ((BinaryExpression)f.Body).Left;

            var node2 = (MemberExpression)left;
            Assert.AreEqual("Length", node2.Member.Name);
        }


    }
}
