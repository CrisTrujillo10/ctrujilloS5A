using ctrujilloS5A.Models;

namespace ctrujilloS5A.Views;

public partial class vPrincipal : ContentPage
{
	public vPrincipal()
	{
		InitializeComponent();
	}

    private void btnInsertar_Clicked(object sender, EventArgs e)
    {
        statusMessage.Text = "";
        App.personRepo.AddNewPerson(txtNombre.Text);

        statusMessage.Text = App.personRepo.statusMessage;

    }

    private void btnListar_Clicked(object sender, EventArgs e)
    {
        statusMessage.Text = "";
        List<Persona> lista = App.personRepo.GetAllPerson();
        listPersonas.ItemsSource = lista;
    }
}