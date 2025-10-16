using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;

namespace cc.isr.Win32.Dialogs.Tests;

/// <summary>   (Unit Test Class) script unit tests requiring no device connection. </summary>
/// <remarks>   2024-08-20. <para>
/// These tests are non-destructive for a TTM instrument. </para></remarks>
[TestClass]
public class OpenFileDialogTests
{
    #region " construction and cleanup "

    /// <summary> Initializes the test class before running the first test. </summary>
    /// <remarks>
    /// Use <see cref="InitializeTestClass(TestContext)"/> to run code before running the first test in the class.
    /// </remarks>
    /// <param name="testContext"> Gets or sets the test context which provides information about
    /// and functionality for the current test run. </param>
    [ClassInitialize()]
    public static void InitializeTestClass( TestContext testContext )
    {
        string methodFullName = $"{testContext.FullyQualifiedTestClassName}.{System.Reflection.MethodBase.GetCurrentMethod()?.Name}";
        try
        {
        }
        catch ( Exception ex )
        {
            Console.WriteLine( $"Failed initializing the test class: {ex}", methodFullName );

            // cleanup to meet strong guarantees
            try
            {
                CleanupTestClass();
            }
            finally
            {
            }

            throw;
        }
    }

    /// <summary> Cleans up the test class after all tests in the class have run. </summary>
    /// <remarks> Use <see cref="CleanupTestClass"/> to run code after all tests in the class have run. </remarks>
    [ClassCleanup]
    public static void CleanupTestClass()
    {
    }

    /// <summary> Initializes the test class instance before each test runs. </summary>
    [TestInitialize()]
    public void InitializeBeforeEachTest()
    {
        Console.WriteLine( $"{this.TestContext?.FullyQualifiedTestClassName}: {DateTime.Now} {TimeZoneInfo.Local}" );
        Assembly assembly = typeof( cc.isr.Win32.Dialogs.FolderPickerDialog ).Assembly;
        Console.WriteLine( $"\t{assembly.FullName} {assembly.GetCustomAttribute<TargetFrameworkAttribute>()?.FrameworkName}" );
    }

    /// <summary> Cleans up the test class instance after each test has run. </summary>
    /// <remarks> David, 2020-09-18. </remarks>
    [TestCleanup()]
    public void CleanupAfterEachTest()
    {
    }

    /// <summary>
    /// Gets or sets the test context which provides information about and functionality for the
    /// current test run.
    /// </summary>
    /// <value> The test context. </value>
    public TestContext? TestContext { get; set; }

    #endregion

    #region " support methods "

    /// <summary>   Gets temporary path under the '~cc.isr` and this class namespace folder name. </summary>
    /// <remarks>   2025-06-03. </remarks>
    /// <param name="firstSubfolderName">   (Optional) [CallerMemberName] Name of the second
    ///                                     subfolder. </param>
    /// <param name="secondSubfolderName">  (Optional) Name of the second subfolder. </param>
    /// <returns>   The temporary path. </returns>
    public static string GetTempPath( [CallerMemberName] string firstSubfolderName = "", string secondSubfolderName = "" )
    {
        string tempPath = Path.Combine( Path.GetTempPath(), "~cc.isr", "Win", "Dialogs", "Tests" );

        if ( !string.IsNullOrWhiteSpace( firstSubfolderName ) )
        {
            tempPath = Path.Combine( tempPath, firstSubfolderName );
        }

        if ( !string.IsNullOrWhiteSpace( secondSubfolderName ) )
        {
            tempPath = Path.Combine( tempPath, secondSubfolderName );
        }

        _ = System.IO.Directory.CreateDirectory( tempPath );
        return tempPath;
    }

    #endregion

    #region " folder picker dialog tests "

    /// <summary>   (Unit Test Method) folder picker can select folder. </summary>
    /// <remarks>   2025-10-09. </remarks>
    [TestMethod( DisplayName = "01. Folder picker dialog can select a folder" )]
    public void FolderPickerCanSelectFolder()
    {
        cc.isr.Win32.Dialogs.FolderPickerDialog? picker = new()
        {
            InitialDirectory = Environment.GetFolderPath( Environment.SpecialFolder.MyDocuments ),
            Title = "Select a folder with files",
            OkButtonLabel = "Select",
            InitialFolderName = "Atomineer",
        };

        if ( picker.ShowDialog( out string details ) )
        {
            string? folder = picker.PathName;
            Assert.IsNotNull( folder, "A folder should be selected." );
            Console.WriteLine( $"Selected folder: {folder}" );

            IEnumerable<string> files = Directory.EnumerateFiles( folder, "*.*", SearchOption.TopDirectoryOnly );
            Assert.IsNotEmpty<string>( files, $"The selected folder '{folder}' should contain files.\n\t{details}" );
            foreach ( string file in files )
                Console.WriteLine( $"Selected file: {file}" );
        }
        else
            Assert.Fail( details );
    }

    #endregion

    #region " file picker dialog tests "

    /// <summary>   (Unit Test Method) loader folder picker can select folder. </summary>
    /// <remarks>   2025-10-09. </remarks>
    [TestMethod( DisplayName = "02. File picker dialog can select a folder" )]
    public void FilePickerCanSelectFile()
    {
        using cc.isr.Win32.Dialogs.FilePickerDialog? picker = new()
        {
            InitialDirectory = Environment.GetFolderPath( Environment.SpecialFolder.MyDocuments ),
            Title = "Select files",
            OkButtonLabel = "Select",
            MultiSelect = true,
        };

        picker.AddFileType( "XML Files", "*.xml" );

        if ( picker.ShowDialog( out string details ) )
        {
            string? fileName = picker.FileName;
            Assert.IsNotNull( fileName, "A file name should be selected." );
            Console.WriteLine( $"Selected file name: {fileName}" );

            string[]? files = picker.FileNames;
            Assert.IsNotNull( files, "" );
            Assert.IsNotEmpty<string>( files, $"The files should be selected." );
            foreach ( string file in files )
                Console.WriteLine( $"Selected file: {file}" );
        }
        else
            Assert.Fail( details );
    }

    #endregion

}

