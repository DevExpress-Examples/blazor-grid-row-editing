<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/515149708/22.1.2%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T1103487)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
# Blazor Grid – Inline Editing and Cell Edit Templates 
 
DevExpress Blazor [Grid](https://docs.devexpress.com/Blazor/403143/grid) allows you to activate [EditRow](https://docs.devexpress.com/Blazor/403454/grid/edit-data-and-validate-input#grideditmodeeditrow) mode, which means users can edit grid data in row editors. This example demonstrates different ways to define editors for grid row cells. 
 
The project includes the following important files: 
 
## Pages/Index.razor 
 
The **Index.razor** code does the following: 
 
* Adds the Blazor [Grid](https://docs.devexpress.com/Blazor/403143/grid) component. 
* Activates the [EditRow](https://docs.devexpress.com/Blazor/403454/grid/edit-data-and-validate-input#grideditmodeeditrow) mode for the Grid.  
* Specifies the [DataColumnCellEditTemplate](https://docs.devexpress.com/Blazor/DevExpress.Blazor.DxGrid.DataColumnCellEditTemplate) to define a common template for Grid edit row cells. Within the template, the [GridEditorValidationMessage](#componentsgrideditorvalidationmessagerazor) custom component is used to display editors and validation errors for them. To select an individual editor for each column, the switch statement is used. 
* For the **Unit Price** column, specifies the individual [CellEditTemplate](https://docs.devexpress.com/Blazor/DevExpress.Blazor.DxGridDataColumn.CellEditTemplate). The template utilizes the [GridEditorValidationMessage](#componentsgrideditorvalidationmessagerazor) and [GridCurrencyEditor](#componentsgridcurrencyeditorrazor) custom components. Note that if you specify an individual cell template, the common template is ignored for the current column. 
* For the **Category Name** column, specifies the individual [CellEditTemplate](https://docs.devexpress.com/Blazor/DevExpress.Blazor.DxGridDataColumn.CellEditTemplate) that contains a combobox editor. 
 
## Components/GridEditorBase.cs 
 
The `GridEditorBase` class is a base class for the [GridCurrencyEditor](#componentsgridcurrencyeditorrazor) component. The class dynamically works with editor values and defines `xxxExpression` properties for correct data validation. 
 
## Components/GridCurrencyEditor.razor 
 
The `GridCurrencyEditor` component specifies a spin editor for grid cells with decimal values. You can reuse this component to define an editor for different columns with similar data. 
 
## Components/GridEditorValidationMessage.razor 
 
The `GridEditorValidationMessage` custom component does the following: 
   
* Renders child content. You can place any editor within this component. 
* Displays a validation icon/error if a user inputs incorrect values.  
 
The component is used in several cases:  
 
* In the grid's common cell template. 
* In the individual cell template for the **Category Name** column. 
* With the [GridCurrencyEditor](#componentsgridcurrencyeditorrazor) component. For this case, you need to call the [StateHasChanged](https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.components.componentbase.statehaschanged?view=aspnetcore-6.0) method in the `GridEditorValidationMessage` component. The method will trigger the `GridEditorValidationMessage` component to render when the currency editor's value changes. Refer to the following topic for details: [ASP.NET Core Razor component rendering](https://docs.microsoft.com/en-us/aspnet/core/blazor/components/rendering?view=aspnetcore-6.0). 

## Documentation 

[Grid - EditRow Mode](https://docs.devexpress.com/Blazor/403454/grid/edit-data-and-validate-input#grideditmodeeditrow)

<!-- default file list -->
## Files to look at:

* [Index.razor](./EditRow/Pages/Index.razor)
* [Components/GridEditorBase.cs](./EditRow/Components/GridEditorBase.cs)
* [Components/GridCurrencyEditor.razor](./EditRow/Components/GridCurrencyEditor.razor)
* [Components/GridEditorValidationMessage.razor](./EditRow/Components/GridEditorValidationMessage.razor)

<!-- default file list end -->
