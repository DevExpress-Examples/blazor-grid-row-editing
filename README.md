<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/515149708/22.1.2%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T1103487)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->
# Blazor Grid – How to activate EditRow mode and define data editors for row cells
 
The DevExpress Blazor [Grid](https://docs.devexpress.com/Blazor/403143/grid) supports inline data editing (via its [EditRow](https://docs.devexpress.com/Blazor/403454/grid/edit-data-and-validate-input#grideditmodeeditrow) mode). This example demonstrates different ways to define editors for grid row cells. 
 
The project includes the following important files: 
 
## Pages/Index.razor 
 
**Index.razor** code performs the following: 
 
* Adds a DevExpress Blazor [Grid](https://docs.devexpress.com/Blazor/403143/grid) component. 
* Activates [EditRow](https://docs.devexpress.com/Blazor/403454/grid/edit-data-and-validate-input#grideditmodeeditrow) mode for the Blazor Grid.  
* Specifies the [DataColumnCellEditTemplate](https://docs.devexpress.com/Blazor/DevExpress.Blazor.DxGrid.DataColumnCellEditTemplate) (used as the common template for Grid edit row cells). Within the template, the **GridEditorValidationMessage** custom component is used to display editors and validation errors. A switch statement is used to select an individual editor for each column.
* The **Unit Price** column uses an individual [CellEditTemplate](https://docs.devexpress.com/Blazor/DevExpress.Blazor.DxGridDataColumn.CellEditTemplate). The template utilizes **GridEditorValidationMessage** and **GridCurrencyEditor** custom components. Note: if you specify an individual cell template, the common template is ignored for the current column. 
* The **Category Name** column uses an individual [CellEditTemplate](https://docs.devexpress.com/Blazor/DevExpress.Blazor.DxGridDataColumn.CellEditTemplate) (contains a combobox editor). 
 
## Components/GridEditorBase.cs 
 
The `GridEditorBase` class is a base class for the **GridCurrencyEditor** component. The class works with editor values and defines `xxxExpression` properties for correct data validation.
 
## Components/GridCurrencyEditor.razor 

The `GridCurrencyEditor` component specifies a spin editor for grid cells with decimal values. You can reuse this component to define an editor for columns with similar data.
 
## Components/GridEditorValidationMessage.razor 
 
The `GridEditorValidationMessage` custom component performs the following actions: 
   
* Renders child content (you can place any editor within this component). 
* Displays a validation icon/error if a user enters incorrect values.  
 
The component is used in several instances:  
 
* Within the Blazor Grid’s common cell template.
* Within the individual cell template for the **Category Name** column. 
* Alongside the **GridCurrencyEditor** component (when used in this manner, you must call the [StateHasChanged](https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.components.componentbase.statehaschanged?view=aspnetcore-6.0) method in the `GridEditorValidationMessage` component). The method will render the `GridEditorValidationMessage` when currency editor value changes. Refer to the following topic for details: [ASP.NET Core Razor component rendering](https://docs.microsoft.com/en-us/aspnet/core/blazor/components/rendering?view=aspnetcore-6.0). 

## Documentation 

[Grid - EditRow Mode](https://docs.devexpress.com/Blazor/403454/grid/edit-data-and-validate-input#grideditmodeeditrow)

<!-- default file list -->
## Files to Review:

* [Index.razor](./EditRow/Pages/Index.razor)
* [Components/GridEditorBase.cs](./EditRow/Components/GridEditorBase.cs)
* [Components/GridCurrencyEditor.razor](./EditRow/Components/GridCurrencyEditor.razor)
* [Components/GridEditorValidationMessage.razor](./EditRow/Components/GridEditorValidationMessage.razor)

<!-- default file list end -->
<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=blazor-grid-row-editing&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=blazor-grid-row-editing&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
