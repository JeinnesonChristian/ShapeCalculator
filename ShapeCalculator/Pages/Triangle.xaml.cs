namespace ShapeCalculator.Pages;

public partial class Triangle : ContentPage
{
	public Triangle()
	{
		InitializeComponent();
		Shell.Current.Title = "Triangle";
		unitPickerTriangle.SelectedIndexChanged += UnitPickerTriangle_SelectedIndexChanged;
		unitPickerTriangle2.SelectedIndexChanged += UnitPickerTriangle2_SelectedIndexChanged;
		unitPickerTriangle3.SelectedIndexChanged += UnitPickerTriangle3_SelectedIndexChanged;
	}

	private void UnitPickerTriangle3_SelectedIndexChanged(object sender, EventArgs e)
	{
		int selectedVolume = unitPickerTriangle3.SelectedIndex;
		if (selectedVolume != -1) 
		{
			string selectedUnitVolume = unitPickerTriangle3.Items[selectedVolume];
		}
	}

	public double Radius { get; set; }
	public double Height { get; set; }

	private void CalculateVolume(object sender, EventArgs e)
	{
		if(double.TryParse(baseRadiusEntry.Text, out double Radius) &&
			double.TryParse(heightEntry.Text, out double Height))
		{
			var selectedUnit = unitPickerTriangle3.SelectedItem?.ToString();
			if(string.IsNullOrEmpty(selectedUnit))
			{
				DisplayAlert("Error", "Please select unit of measurement", "OK");
				return;
			}
			else
			{
                UpdateConversionFactor();
                double Volume = CalculateConeVolume(Radius, Height);
				double convertedVolume = ConvertVolume(Volume, selectedUnit);
                resultVolume.Text = convertedVolume.ToString("F2");
            }
            
		}
		else
		{
            DisplayAlert("Error", "Please enter valid numeric inputs", "OK");
        }
	}

	private double CalculateConeVolume(double radius, double height)
	{
		return (1.0 / 3.0) * Math.PI * Math.Pow(radius, 2) * height;
    }
	private double ConvertVolume(double volume, string selectedUnit)
	{
		return volume * _conversionFactor;
	}
	private double _conversionFactor = 1.0;
	private void UpdateConversionFactor()
	{
		var selectedUnit = unitPickerTriangle3.SelectedItem.ToString();
		_conversionFactor = GetConversionFactor(selectedUnit);
	}
    private double GetConversionFactor(string unit)
	{
        switch (unit)
        {
            case "Inches":
                return 0.0254; // Convert inches to meters
            case "Centimeters":
                return 0.01; // Convert centimeters to meters
            case "Kilometers":
                return 1000.0; // Convert kilometers to meters
            default:
                return 1.0; // Default to meters (no conversion)
        }
    }




	private void UnitPickerTriangle2_SelectedIndexChanged(object sender, EventArgs e)
	{
		int selectedPerimeter = unitPickerTriangle2.SelectedIndex;
		if (selectedPerimeter != -1)
		{
			string selectedUnitPerimeter = unitPickerTriangle2.Items[selectedPerimeter];
		}
	}

	public double Side1 { get; set; }
	public double Side2 { get; set; }
	public double Side3 { get; set; }

	private void CalculatePerimeter(object sender, EventArgs e)
	{
		if(double.TryParse(perimeterEntryTriangle.Text, out double Side1) &&
			double.TryParse(perimeterEntryTriangle2.Text, out double Side2) &&
			double.TryParse(perimeterEntryTriangle3.Text, out double Side3))
		{
            var selectedUnit = unitPickerTriangle2.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedUnit))
            {
                DisplayAlert("Error", "Please select unit of measurement", "OK");
				return;
            }
      
			double convertedSide1 = Side1;
			double convertedSide2 = Side2;
			double convertedSide3 = Side3;
			switch(selectedUnit)
			{
                case "Inches":
                    convertedSide1 *= 0.0254; // Convert inches to meters
					convertedSide2 *= 0.0254;
					convertedSide3 *= 0.0254;
                    break;
                case "Centimeters":
					convertedSide1 *= 0.01;
                    convertedSide2 *= 0.01;
					convertedSide3 *= 0.01;// Convert centimeters to meters
                    break;
                case "Kilometers":
					convertedSide1 *= 1000.0;
					convertedSide2 *= 1000.0; 
                    convertedSide3 *= 1000.0; // Convert kilometers to meters
                    break;
                default:
                    convertedSide1 *= 1.0;
					convertedSide2 *= 1.0;
					convertedSide3 *= 1.0;// Default to meters (no conversion)
                    break;
            }
			
			double Perimeter = CalculatePerimeterResult(convertedSide1, convertedSide2, convertedSide3);
			resultPerimeter.Text = Perimeter.ToString("F2");
        }
		else
		{
            DisplayAlert("Error", "Please enter a valid numeric inputs", "OK");
        }
	}

    private double CalculatePerimeterResult(double side1, double side2, double side3)
    {
        return side1 + side2 + side3;
    }



    private void UnitPickerTriangle_SelectedIndexChanged(object sender, EventArgs e)
	{
		int selectedIndexArea = unitPickerTriangle.SelectedIndex;
        if (selectedIndexArea != -1)
		{
			string selectedUnitArea = unitPickerTriangle.Items[selectedIndexArea];
		}
    }

    public double Edge1 { get; set; }
	public double Edge2 { get; set; }
	
	private void CalculateArea(object sender, EventArgs e)
	{
		if(double.TryParse(edgeEntry1.Text, out double Edge1) && 
			double.TryParse(edgeEntry2.Text, out double Edge2))
		{
            var selectedUnit = unitPickerTriangle.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(selectedUnit))
            {
                DisplayAlert("Error", "Please select unit of measurement", "OK");
				return;
            }
            
			double convertedEdge1 = Edge1;
			double convertedEdge2 = Edge2;

			switch(selectedUnit)
			{
                case "Inches":
                    convertedEdge1 *= 0.0254; // Convert inches to meters
                    convertedEdge2 *= 0.0254;
                    break;
                case "Centimeters":
                    convertedEdge1 *= 0.01; // Convert centimeters to meters
                    convertedEdge2 *= 0.01;
                    break;
                case "Kilometers":
                    convertedEdge1 *= 1000.0; // Convert kilometers to meters
                    convertedEdge2 *= 1000.0;
                    break;
                    // No conversion needed for meters
            }
			double area = Math.Round((convertedEdge1 * convertedEdge2)/2);
			resultArea.Text = area.ToString("F2");
        }
		else
		{
            DisplayAlert("Error", "Please enter a valid numeric inputs", "OK");
        }
	}

    private void ClearInput(object sender, EventArgs e)
    {
        edgeEntry1.Text = string.Empty;
        edgeEntry2.Text = string.Empty;
        unitPickerTriangle.SelectedIndex = -1;
        resultArea.Text = string.Empty;
        
		perimeterEntryTriangle.Text = string.Empty;
		perimeterEntryTriangle2.Text = string.Empty;
		perimeterEntryTriangle3.Text = string.Empty;
		unitPickerTriangle2.SelectedIndex = -1;
		resultPerimeter.Text = string.Empty;

		baseRadiusEntry.Text = string.Empty;
		heightEntry.Text = string.Empty;
		unitPickerTriangle3.SelectedIndex = -1;
		resultVolume.Text = string.Empty;

    }

}