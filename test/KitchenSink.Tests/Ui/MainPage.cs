using KitchenSink.Tests.Ui.ArrayPage;
using KitchenSink.Tests.Ui.BooleanPage;
using KitchenSink.Tests.Ui.CustomPage;
using KitchenSink.Tests.Ui.ObjectPage;
using KitchenSink.Tests.Ui.StringPage;
using KitchenSink.Tests.Utilities;
using OpenQA.Selenium;

namespace KitchenSink.Tests.Ui
{
    public class MainPage : BasePage
    {
        public MainPage(IWebDriver driver) : base(driver)
        {
        }

        public MainPage GoToMainPage()
        {
            Driver.Navigate().GoToUrl(Config.KitchenSinkUrl + "/MainPage");
            return this;
        }

        public DatepickerPage GoToDatePickerPage()
        {
            ClickOn(DatepickerPageLink);
            return new DatepickerPage(Driver);
        }

        public DropdownPage GoToDropdownPage()
        {
            ClickOn(DropdownPageLink);
            return new DropdownPage(Driver);
        }

        public NestedPartialsPage GoToNestedPartialsPage()
        {
            ClickOn(NestedPartialsPageLink);
            return new NestedPartialsPage(Driver);
        }

        public TablePage GoToTablePage()
        {
            ClickOn(TablePageLink);
            return new TablePage(Driver);
        }

        public ValidationPage GoToValidationPage()
        {
            ClickOn(ValidationPageLink);
            return new ValidationPage(Driver);
        }

        public CheckboxPage GoToCheckboxPage()
        {
            ClickOn(CheckboxPageLink);
            return new CheckboxPage(Driver);
        }

        public ButtonPage GoToButtonPage()
        {
            ClickOn(ButtonPageLink);
            return new ButtonPage(Driver);
        }

        public TextPage GoToTextPage()
        {
            ClickOn(TextPageLink);
            return new TextPage(Driver);
        }

        public PaginationPage GoToPaginationPage()
        {
            ClickOn(PaginationPageLink);
            return new PaginationPage(Driver);
        }

        public AutoCompletePage GoToAutoCompletePage()
        {
            ClickOn(AutoCompletePageLink);
            return new AutoCompletePage(Driver);
        }

        public PasswordPage GoToPasswordPage()
        {
            ClickOn(PasswordPageLink);
            return new PasswordPage(Driver);
        }

        public RedirectPage GoToRedirectPage()
        {
            ClickOn(RedirectPageLink);
            return new RedirectPage(Driver);
        }

        public TextareaPage GoToTextareaPage()
        {
            ClickOn(TextareaPageLink);
            return new TextareaPage(Driver);
        }

        public FileUploadPage GoToFileUploadPage()
        {
            ClickOn(FileUploadPageLink);
            return new FileUploadPage(Driver);
        }

        public ToggleButtonPage GoToToggleButtonPage()
        {
            ClickOn(ToggleButtonPageLink);
            return new ToggleButtonPage(Driver);
        }

        public DatagridPage GoToDataGridPage()
        {
            ClickOn(DataGridPageLink);
            return new DatagridPage(Driver);
        }

        public BreadcrumbPage GoToBreadcrumbPage()
        {
            ClickOn(BreadcrumbPageLink);
            return new BreadcrumbPage(Driver);
        }

        public MultiselectPage GoToMultiselectPage()
        {
            ClickOn(MultiselectPageLink);
            return new MultiselectPage(Driver);
        }

        public RadioPage GoToRadioPage()
        {
            ClickOn(RadioPageLink);
            return new RadioPage(Driver);
        }

        public RadiolistPage GoToRadiolistPage()
        {
            ClickOn(RadiolistPageLink);
            return new RadiolistPage(Driver);
        }
    }
}
