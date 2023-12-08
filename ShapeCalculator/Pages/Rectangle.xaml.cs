namespace ShapeCalculator.Pages;

public partial class Rectangle : ContentPage
{
    public Rectangle()
    {
        InitializeComponent();
        Shell.Current.Title = "Rectangle";
        unitPickerRectangle.SelectedIndexChanged += UnitPickerRectangle_SelectedIndexChanged;
        unitPickerRectangle2.SelectedIndexChanged += UnitPickerRectangleRT_SelectedIndexChanged;
    }

    
    public double LengthRT { get; set; }
    public double HeightRT { get; set; }
    public double WidthRT { get; set; }

   
    public double Volume
    {
        get { return LengthRT * WidthRT * HeightRT; }
    }


    private void CalculateRectangularTank(object sender, EventArgs e)
    {
        if (double.TryParse(lengthEntryRT.Text, out double LengthRT) &&
            double.TryParse(widthEntryRT.Text, out double WidthRT) &&
            double.TryParse(heightEntryRT.Text, out double HeightRT))
        {
            var selectedUnit = unitPickerRectangle2.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedUnit))
            {
                DisplayAlert("Error", "Please select a unit of measurement", "OK");
                return;
            }

            double convertedLength = LengthRT;
            double convertedWidth = WidthRT;
            double convertedHeight = HeightRT;

            // Perform unit conversions if needed
            switch (selectedUnit)
            {
                case "Inches":
                    // Convert dimensions to meters
                    convertedLength = LengthRT * 0.0254; // 1 inch = 0.0254 meters
                    convertedWidth = WidthRT * 0.0254;
                    convertedHeight = HeightRT * 0.0254;
                    break;
                case "Centimeters":
                    // Convert dimensions to meters
                    convertedLength = LengthRT * 0.01; // 1 centimeter = 0.01 meters
                    convertedWidth = WidthRT * 0.01;
                    convertedHeight = HeightRT * 0.01;
                    break;
                case "Kilometers":
                    // Convert dimensions to meters
                    convertedLength = LengthRT * 1000; // 1 kilometer = 1000 meters
                    convertedWidth = WidthRT * 1000;
                    convertedHeight = HeightRT * 1000;
                    break;
                    // For "Meters," no conversion is needed
            }
            double Volume = convertedLength * convertedWidth * convertedHeight;
            volumeEntry.Text = Volume.ToString("F2");
        }
        else
        {
            DisplayAlert("Error", "Please enter a valid numeric inputs", "OK");
        }
    }


    private void UnitPickerRectangleRT_SelectedIndexChanged(object sender, EventArgs e)
    {
        int selectedIndexRT = unitPickerRectangle2.SelectedIndex;
        if (selectedIndexRT != -1)
        {
            string selectedUnitRT = unitPickerRectangle2.Items[selectedIndexRT];
        }
    }

    private void UnitPickerRectangle_SelectedIndexChanged(object sender, EventArgs e)
    {
        int selectedIndex = unitPickerRectangle.SelectedIndex;
        if (selectedIndex != -1)
        {
            string selectedUnit = unitPickerRectangle.Items[selectedIndex];
        }
    }

    private double length = 0;
    private double width = 0;

    private double Length
    {
        get { return length; }
        set { length = value; }
    }

    private double Width
    {
        get { return width; }
        set { width = value; }
    }

    public double Area { get; set; }
    public double Perimeter { get; set; }

    private void CalculateResult(object sender, EventArgs e)
    {
        if (double.TryParse(lengthEntry.Text, out double length) &&
            double.TryParse(widthEntry.Text, out double width))
        {
            var selectedUnit = unitPickerRectangle.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedUnit))
            {
                DisplayAlert("Error", "Please select a unit of measurement", "OK");
                return;
            }

            var rectangle = new Rectangle { Length = length, Width = width };

            switch (selectedUnit)
            {
                case "Inches":
                    Area = rectangle.Length * rectangle.Width;
                    Perimeter = 2 * (rectangle.Length + rectangle.Width);
                    break;
                case "Centimeters":
                    // Convert length and width to centimeters (assuming 1 inch = 2.54 cm)
                    var lengthInCentimeters = rectangle.Length * 2.54;
                    var widthInCentimeters = rectangle.Width * 2.54;
                    Area = lengthInCentimeters * widthInCentimeters;
                    Perimeter = 2 * (lengthInCentimeters + widthInCentimeters);
                    break;
                case "Meters":
                    // Convert length and width to meters (assuming 1 meter = 100 centimeters)
                    var lengthInMeters = rectangle.Length * 0.01;
                    var widthInMeters = rectangle.Width * 0.01;
                    Area = lengthInMeters * widthInMeters;
                    Perimeter = 2 * (lengthInMeters + widthInMeters);
                    break;
                case "Kilometers":
                    // Convert length and width to kilometers (assuming 1 kilometer = 1000 meters)
                    var lengthInKilometers = rectangle.Length * 0.00001;
                    var widthInKilometers = rectangle.Width * 0.00001;
                    Area = lengthInKilometers * widthInKilometers;
                    Perimeter = 2 * (lengthInKilometers + widthInKilometers);
                    break;
            }
            areaEntry.Text = Area.ToString();
            perimeterEntry.Text = Perimeter.ToString("F2");
        }
        else
        {
            DisplayAlert("Error", "Please enter a valid numeric inputs", "OK");
        }
    }

    private void ClearInput(object sender, EventArgs e)
    {
        lengthEntry.Text = string.Empty;
        widthEntry.Text = string.Empty;
        unitPickerRectangle.SelectedIndex = -1;
        areaEntry.Text = string.Empty;
        perimeterEntry.Text = string.Empty;
        
        lengthEntryRT.Text = string.Empty;
        widthEntryRT.Text = string.Empty;
        heightEntryRT.Text = string.Empty;
        volumeEntry.Text = string.Empty;
        unitPickerRectangle2.SelectedIndex = -1;
    }




}