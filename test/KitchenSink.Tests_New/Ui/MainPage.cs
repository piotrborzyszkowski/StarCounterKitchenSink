using KitchenSink.Tests_New.Ui.ArrayPage;
using KitchenSink.Tests_New.Ui.BooleanPage;
using KitchenSink.Tests_New.Ui.CustomPage;
using KitchenSink.Tests_New.Ui.ObjectPage;
using KitchenSink.Tests_New.Ui.StringPage;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace KitchenSink.Tests_New.Ui
{
    public class MainPage : BasePage
    {
        public MainPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(Driver, this);
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
    }
}
