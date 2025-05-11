using ctrujilloS5A.Models;

namespace ctrujilloS5A.Views;

public partial class vPrincipal : ContentPage
{
	public vPrincipal()
	{
		InitializeComponent();
	}

    Persona personaSeleccionada;

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

    private void listPersonas_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        personaSeleccionada = (Persona)e.CurrentSelection.FirstOrDefault();
        if (personaSeleccionada != null)
        {
            txtNombre.Text = personaSeleccionada.Name;
        }
    }

    private void btnActualizar_Clicked(object sender, EventArgs e)
    {
        if(personaSeleccionada !=null)
        {
            App.personRepo.UpdatePerson(personaSeleccionada.Id, txtNombre.Text);
            statusMessage.Text = App.personRepo.statusMessage;
            txtNombre.Text = "";
            listPersonas.ItemsSource = App.personRepo.GetAllPerson();
        }
        else
        {
            statusMessage.Text = "Seleccione una persona para actualizar";
        }
    }

    private void btnEliminar_Clicked(object sender, EventArgs e)
    {
        if (personaSeleccionada != null)
        {
            App.personRepo.DeletePerson(personaSeleccionada.Id);
            statusMessage.Text = App.personRepo.statusMessage;
            txtNombre.Text = "";
            listPersonas.ItemsSource = App.personRepo.GetAllPerson();
        }
        else
        {
            statusMessage.Text = "Seleccione una persona para eliminar";
        }
    }
}