using DevExpress.Blazor;
using Microsoft.AspNetCore.Components;
using System.Collections.Concurrent;
using System.Linq.Expressions;
using System.Reflection;

namespace EditRow.Components {
    public class GridEditorBase : ComponentBase {
        PropertyAccessor PropAccessor { get; set; }

        protected Expression ValueExpression { get; set; }
        protected object EditModel => EditTemplateContext.EditModel;
        protected string FieldName => EditTemplateContext.DataColumn.FieldName;

        [Parameter]
        public GridDataColumnCellEditTemplateContext EditTemplateContext { get; set; }

        protected override void OnInitialized() {
            PropAccessor = PropertyAccessor.Find(EditModel.GetType(), FieldName);
            ValueExpression = Expression.Lambda(
                Expression.Property(Expression.Constant(EditModel), FieldName)
            );
        }

        protected object GetValue() {
            return PropAccessor.Get(EditModel);
        }
        protected void SetValue(object value) {
            PropAccessor.Set(EditModel, value);
        }
    }

    public class PropertyAccessor {
        static readonly ParameterExpression _propertyParameter = Expression.Parameter(typeof(object));
        static readonly ParameterExpression _ownerParameter = Expression.Parameter(typeof(object));

        public PropertyAccessor(PropertyInfo info) {
            var propExpression = Expression.Property(
                Expression.Convert(_ownerParameter, info.DeclaringType), info.Name);

            Get = Expression.Lambda<Func<object, object>>(
                Expression.Convert(propExpression, typeof(object)),
                _ownerParameter
            ).Compile();

            Set = Expression.Lambda<Action<object, object>>(
                Expression.Assign(propExpression,
                    Expression.Convert(_propertyParameter, info.PropertyType)),
                _ownerParameter, _propertyParameter
            ).Compile();
        }

        public Func<object, object> Get { get; }
        public Action<object, object> Set { get; }

        static ConcurrentDictionary<Type, Dictionary<string, PropertyAccessor>> PropertyAccessors { get; } = new();
        public static PropertyAccessor Find(Type type, string name) {
            var dict = PropertyAccessors.GetOrAdd(
                type,
                t => t.GetProperties().ToDictionary(p => p.Name, p => new PropertyAccessor(p))
            );
            return dict[name];
        }
    }
}
