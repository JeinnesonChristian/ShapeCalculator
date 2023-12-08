using Microsoft.VisualBasic;
using System.ComponentModel;

namespace ShapeCalculator.Pages;

public partial class Circle : ContentPage
{
	public Circle()
	{
		InitializeComponent();
		Shell.Current.Title = "Circle";
		unitPicker.SelectedIndexChanged += UnitPickerCircle_SelectedIndexChanged;
	}
	
	private double radius = 0;

	public double Radius
	{
		get { return radius; }
		set { radius = value; CalculateResult(); }
	}

	public double Area { get; set; }
	public double Perimeter {  get; set; }
	public double VolumeSphere { get; set; }

	private void UnitPickerCircle_SelectedIndexChanged(object sender, EventArgs e)
	{
		int selectedIndex = unitPicker.SelectedIndex;
		if (selectedIndex != -1)
		{
			string selectedUnit = unitPicker.Items[selectedIndex];
		}
	}

	private void CalculateResult()
	{
		Area = Math.PI * Math.Pow(Radius, 2);
		Perimeter = 2 * Math.PI * radius;
		VolumeSphere = (4.0 / 3.0) * Math.PI * Math.Pow(radius, 3);
	}

	private double ConvertUnitoOfRadius(double radius, string unit)
	{
		switch (unit)
		{
			case "Inches":
				return radius / 39.97;
			case "Centimeters":
				return radius / 100.0;
			case "Kilometers":
				return radius * 1000.0;
			default:
				return radius;
		}
	}
	private void CalculateResultCircle(object sender, EventArgs e)
	{
		if (double.TryParse(radiusEntry.Text, out double radius))
		{
			if(unitPicker.SelectedItem == null)
			{
				DisplayAlert("Error", "Please select a unit of measurement", "OK");
				return;
			}

			string selectedUnit = unitPicker.SelectedItem.ToString();
			double convertedRadius = ConvertUnitoOfRadius(radius, selectedUnit);

			Radius = convertedRadius;
			areaEntry.Text = Area.ToString("F2");
			perimeterEntry.Text = Perimeter.ToString("F2");
			volumeAndSphereEntry.Text = VolumeSphere.ToString("F2");
			
		}
		else
		{
			DisplayAlert("Error", "Please enter a valid numeric inputs", "OK");
		}
	}
	private void ClearInput(object sender, EventArgs e)
	{
		radiusEntry.Text = string.Empty;
		unitPicker.SelectedIndex = -1;
		areaEntry.Text = string.Empty;
		perimeterEntry.Text = string.Empty;
		volumeAndSphereEntry.Text = string.Empty;
	}	
}