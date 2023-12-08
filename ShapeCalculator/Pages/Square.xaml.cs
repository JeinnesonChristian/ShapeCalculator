namespace ShapeCalculator.Pages;

public partial class Square : ContentPage
{
	public Square()
	{
		InitializeComponent();
		Shell.Current.Title = "Square";
		unitPickerSquare.SelectedIndexChanged += UnitPickerSquare_SelectedIndexChanged;
	}

	private void UnitPickerSquare_SelectedIndexChanged(object sender, EventArgs e)
	{
		int selectedIndex = unitPickerSquare.SelectedIndex;
		if (selectedIndex != -1)
		{
			string selectedUnit = unitPickerSquare.Items[selectedIndex];
		}
	}
	private double side = 0;
	
	private double Side
	{
		get { return side; } 
		set {  side = value; CalculateResult(); }
	}

	public double Area { get; set; }
	public double Perimeter { get; set; }
	public double VolumeAndCube { get; set; }

	private void CalculateResult()
	{
		Area = Math.Pow(Side, 2);
		Perimeter = Side * 4;
		VolumeAndCube = Math.Pow(Side, 3);
	}

    private double ConvertUnitOfSide(double side, string unit)
    {
        switch (unit)
        {
            case "Inches":
                return side; 
            case "Centimeters":
                return side * 2.54; 
            case "Meters":
                return side * 0.0254; 
            case "Kilometers":
                return side * 0.0000254; 
            default:
                return side; 
        }
    }

	private void CalculateResultSquare(object sender, EventArgs e)
	{
		if(double.TryParse(sideEntry.Text, out double side))
		{
			if(unitPickerSquare.SelectedItem == null)
			{
				DisplayAlert("Error", "Please select a unit of measurement", "OK");
				return;
			}

			string selectedUnit = unitPickerSquare.SelectedItem.ToString();
			double convertedSide = ConvertUnitOfSide(side, selectedUnit);
			
			Side = convertedSide;
			areaEntry.Text = Area.ToString("F2");
			perimeterEntry.Text = Perimeter.ToString("F2");
			volumeAndCubeEntry.Text = VolumeAndCube.ToString("F2");
        }
		else
		{
			DisplayAlert("Error", "Please enter a valid numeric input", "OK");
		}
	}

    private void ClearInput(object sender, EventArgs e)
    {
        sideEntry.Text = string.Empty;
        unitPickerSquare.SelectedIndex = -1;
        areaEntry.Text = string.Empty;
        perimeterEntry.Text = string.Empty;
        volumeAndCubeEntry.Text = string.Empty;
    }
}