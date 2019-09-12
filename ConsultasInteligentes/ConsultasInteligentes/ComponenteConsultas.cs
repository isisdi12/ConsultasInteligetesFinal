using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaLogica;
using CapaDiseno;

namespace ConsultasInteligentes
{
    public partial class ComponenteConsultas : UserControl
    {
        logica log = new logica();

        private string QuerySimple,QuerySimpleComplete,QueryComplejoCondicional,QueryComplejoComp, QueryComplejoOrden, QueryComplejoTotal;
        private string QuerySimple1, QuerySimpleComplete1, QueryComplejoCondicional1, QueryComplejoComp1, QueryComplejoOrden1, QueryComplejoTotal1;
        int contadorAgregar = 0, ContadorLogico=0, ContadorComparacion=0, ContadorAgrup=0;
        List<int> lista = new List<int>();
        List<string> consultas = new List<string>();
        int idConsulta;

        public ComponenteConsultas()
        {
            InitializeComponent();
            gbLogica.Enabled = false;
            gbComparacion.Enabled = false;
            gbTipoOrdenamiento.Enabled = false;
            gbAgrupar.Enabled = false;
            log.tablas(cboTablasGeneral);
            log.tablas(cboTablaGeneral1);
            log.CargarConsultas(Cbo_ListaTablas, lista, consultas);
            

            //log.conect();
            // cboTablasGeneral=log.listatablas();


        }


        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboCampos.Text = "";
            cboCampos.Items.Clear();
            log.campos(cboCampos, cboTablasGeneral.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (cboOpciones.Checked)
            {
                QuerySimple = " * ";
                cboCampos.Enabled = false;
                txtNombreRepresentativo.Enabled = false;
                QuerySimpleComplete = " SELECT " + QuerySimple + " FROM " + cboTablasGeneral.Text;
                MessageBox.Show(QuerySimpleComplete);


            }
            else
            {

                QuerySimpleComplete = "";
                cboCampos.Enabled = true;
                txtNombreRepresentativo.Enabled = true;
                if (txtNombreConsulta.Text == "" | cboCampos.Text == "" | cboTablasGeneral.Text == "" | txtNombreRepresentativo.Text == "")
                {
                    MessageBox.Show("No ha elegido datos");
                }
                else
                {
                    ContadorLogico++;
                    if (ContadorLogico > 1)
                    {
                        MessageBox.Show("No puede agregar mas de 2 querys simples");
                    }
                    else
                    {
                        QuerySimpleComplete = "SELECT " + QuerySimple + " FROM " + cboTablasGeneral.Text;
                        MessageBox.Show(QuerySimpleComplete);
                    }
                }

            }


            //log.listatablas();

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (cboCampoLogico.Text == "" | cboOpLogico.Text == "" | txtValorLogico.Text == "")
            {
                MessageBox.Show("Existen Campos Vacíos");
            }
            else
            {

                QueryComplejoCondicional += cboOpLogico.Text + " " + cboCampoLogico.Text + " = " + txtValorLogico.Text;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            txtValorComp.Text="";
            cboComparador.SelectedIndex = 0;
            cboComparador.SelectedIndex = 0;
            cboCampoComparador.SelectedIndex = 0;
            log.campos(cboCampoComparador, cboTablasGeneral.Text);
            QueryComplejoComp = "";
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void TextBox7_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void btnAgregarOrden_Click(object sender, EventArgs e)
        {

            if (cboTipoSeleccion.Text == ""|cboCampoOrden.Text=="")
            {
                MessageBox.Show("Existen Campos Vacíos");
            }
            else
            {
                if (cboTipoSeleccion.Text == "Ordenar")
                {
                    // gbTipoOrdenamiento.Enabled = true;
                    if (rbAscendente.Checked)
                    {
                        QueryComplejoOrden = "ORDER BY " + cboCampoOrden.Text + " ASC ";
                    }
                    else if (rbDescendente.Checked)
                    {
                        QueryComplejoOrden = "ORDER BY " + cboCampoOrden.Text + " DESC ";
                    }
                }
                else if (cboTipoSeleccion.Text == "Agrupar")
                {
                    // gbTipoOrdenamiento.Enabled = false;
                    QueryComplejoOrden = "GROUP BY " + cboCampoOrden.Text;
                }
            }
           
            MessageBox.Show(QueryComplejoOrden);
           
        }

        private void btnCrearConsulta_Click(object sender, EventArgs e)
        {

            if (QuerySimpleComplete == "" | QueryComplejoCondicional == "" | QueryComplejoComp == "" | QueryComplejoOrden == "")
            {
                MessageBox.Show("No ha creado ninguna cadena");
            }
            else
            {

                if (cbCondiciones.Checked)
                {
                    QueryComplejoTotal = QuerySimpleComplete + " " + QueryComplejoComp + " " + QueryComplejoCondicional + " " + QueryComplejoOrden;

                }
                else
                {
                    QueryComplejoTotal = QuerySimpleComplete;

                }
            }
            txtCadena.Text = QueryComplejoTotal;
            log.InsertarCampos(QueryComplejoTotal, txtNombreConsulta.Text, "Admin");
            QuerySimpleComplete = "";
            QueryComplejoComp = "";
            QueryComplejoOrden = "";
            QueryComplejoTotal = "";
        }

        private void btnCancelarGeneral_Click(object sender, EventArgs e)
        {
            txtSeleccionados.Text="";
            cboTablasGeneral.SelectedIndex = 0;
            cboCampos.SelectedIndex = 0;
            txtNombreConsulta.Text = "";
            txtNombreRepresentativo.Text = "";
            ContadorLogico = 0;
            QuerySimple = "";
            QuerySimpleComplete = "";
        }

        private void btnCancelarLogico_Click(object sender, EventArgs e)
        {
            txtValorLogico.Text="";
            cboOpLogico.SelectedIndex = 0;
            cboCampoLogico.SelectedIndex = 0;
            log.campos(cboCampoLogico, cboTablasGeneral.Text);
            QueryComplejoCondicional = "";


        }

        private void btnCancelarAgrup_Click(object sender, EventArgs e)
        {
            cboTipoSeleccion.SelectedIndex = 0;
            cboCampoOrden.SelectedIndex = 0;
            log.campos(cboCampoOrden, cboTablasGeneral.Text);
            QueryComplejoOrden = "";

        }

        private void btnBorrarProgreso_Click(object sender, EventArgs e)
        {
     
            QuerySimple = "";
            QueryComplejoTotal = "";
            QuerySimpleComplete = "";
            QueryComplejoComp = "";
            QueryComplejoCondicional = "";
            QueryComplejoOrden = "";
            txtNombreConsulta.Text = "";
            gbComparacion.Enabled = false;
            gbLogica.Enabled = false;
            gbAgrupar.Enabled = false;
            txtCadena.Text = "";

            cboTablasGeneral.Text = "";
            cboCampos.Text = "";
            txtNombreRepresentativo.Text = "";
            txtValorLogico.Text = "";
            cboOpLogico.Text = "";
            cboCampoLogico.Text = "";
            txtValorComp.Text = "";
            cboComparador.Text = "";
            cboComparador.Text = "";
            cboCampoComparador.Text = "";
            cboTipoSeleccion.Text = "";
            cboCampoOrden.Text = "";


        }


        private void button3_Click_1(object sender, EventArgs e)
        {
            if(TxtEID.Text == "")
            {
                MessageBox.Show("Debe ingresar el nombre de la consulta para la busqueda");
            }
            else
            {
                gbLogica1.Enabled = false;
                gbComparacion1.Enabled = false;
                gbTipoOrdenamiento1.Enabled = false;
                gbAgrupar1.Enabled = false;

                log.txt(TxtNConsulta, TxtEID.Text);
                log.txt1(TxtEditarCadena, TxtEID.Text);
            }
            
        }

        private void BtnEditarA1_Click(object sender, EventArgs e)
        {
            List<string> listacampos = new List<string>();

            


            if (TxtNConsulta.Text == "" | CboGeneralCampos.Text == "" | cboTablaGeneral1.Text == "" | TxtNRepresentativoEdit.Text == "")
            {
                
                    MessageBox.Show("No puede dejar campos vacíos");
                

                MessageBox.Show("No puede dejar campos vacíos");
            }

            else
            {
                contadorAgregar++;
                if (contadorAgregar == 1)
                {
                    if (AgregarCondiciones1.Checked)
                    {
                        QuerySimple1 = " * ";
                    }
                    else
                    {
                        if (TxtNRepresentativoEdit.Text != " ")
                        {
                            QuerySimple1 += CboGeneralCampos.Text + " as " + TxtNRepresentativoEdit.Text;
                        }
                        else
                        {
                            QuerySimple1 += CboGeneralCampos.Text;
                        }

                    }
                }
                else if (contadorAgregar >= 1)
                {

                    if (TxtNRepresentativoEdit.Text != "")
                    {
                        QuerySimple1 += "," + CboGeneralCampos.Text + " as " + TxtNRepresentativoEdit.Text;
                    }
                    else
                    {
                        QuerySimple1 += " ," + CboGeneralCampos.Text;
                    }

                }


                listacampos.Add(QuerySimple1);
                for (int j = 0; j < listacampos.Count; j++)
                {
                    cboCampoSelectEdit.Items.Add(listacampos[j]);
                }

            }

            //limpiar
        }

        private void BtnEditarA2_Click(object sender, EventArgs e)
        {
            cboCampoSelectEdit.Items.Clear();

            QuerySimpleComplete1 = "SELECT " + QuerySimple1 + " FROM " + cboTablaGeneral1.Text;
            //log.listatablas();
            MessageBox.Show(QuerySimpleComplete1);
        }

        private void BtnEditarC1_Click(object sender, EventArgs e)
        {
            TxtNConsulta.Clear();
            TxtNRepresentativoEdit.Clear();
            cboTablaGeneral1.SelectedIndex = 0;
            CboGeneralCampos.SelectedIndex = 0;
        }

        private void BtnEditarA3_Click(object sender, EventArgs e)
        {
            cboOLogico.Items.Clear();
            cboCondicionesCampo.Items.Clear();

            if (cboCondicionesCampo.Text == "" | cboOLogico.Text == "" | TxtCondicionesValor.Text == "")
            {
                MessageBox.Show("Existen Campos Vacíos");
            }
            else
            {

                QueryComplejoCondicional1 += cboOLogico.Text + " " + cboCondicionesCampo.Text + " = " + TxtCondicionesValor.Text;
            }
        }

        private void BtnEditarC2_Click(object sender, EventArgs e)
        {
            TxtCondicionesValor.Clear();
            cboOLogico.SelectedIndex = 0;
            cboCondicionesCampo.SelectedIndex = 0;

        }

        private void BtnEditarA4_Click(object sender, EventArgs e)
        {
            cboComparacionTipo.Items.Clear();
            cboComparacionCampo.Items.Clear();

            if (cboComparacionCampo.Text == "" | cboComparacionTipo.Text == "" | TxtComparaValor.Text == "")
            {
                MessageBox.Show("Existen Campos Vacios");
            }
            else
            {
                ContadorComparacion++;
                if (ContadorComparacion > 1)
                {
                    MessageBox.Show("No puede agregar 2 comparaciones en un mismo query");
                }
                else
                {
                    QueryComplejoComp1 = cboComparacionTipo.Text + " " + cboComparacionCampo.Text + " = " + TxtComparaValor.Text;

                }
            }
        }

        private void BtnEditarC3_Click(object sender, EventArgs e)
        {
            TxtComparaValor.Clear();
            cboComparacionTipo.SelectedIndex = 0;
            cboComparacionCampo.SelectedIndex = 0;
        }

        private void BtnEditarA5_Click(object sender, EventArgs e)
        {
            

            if (cboOrdenarAgrupar.Text == "" | cboAgruparCampo.Text == "")
            {
                MessageBox.Show("Existen Campos Vacíos");
            }
            else
            {
                if (cboOrdenarAgrupar.Text == "Ordenar")
                {
                    // gbTipoOrdenamiento.Enabled = true;
                    if (RBasc.Checked)
                    {
                        QueryComplejoOrden1 = "ORDER BY " + cboAgruparCampo.Text + " ASC ";
                    }
                    else if (RBdesc.Checked)
                    {
                        QueryComplejoOrden1 = "ORDER BY " + cboAgruparCampo.Text + " DESC ";
                    }
                }
                else if (cboOrdenarAgrupar.Text == "Agrupar")
                {
                    // gbTipoOrdenamiento.Enabled = false;
                    QueryComplejoOrden1 = "GROUP BY " + cboAgruparCampo.Text;
                }
            }

            MessageBox.Show(QueryComplejoOrden1);
        }

        private void BtnEditarC4_Click(object sender, EventArgs e)
        {
            cboOrdenarAgrupar.SelectedIndex = 0;
            cboAgruparCampo.SelectedIndex = 0;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            limpiar();

        }

        private void Button4_Click_1(object sender, EventArgs e)
        {

            if (QuerySimpleComplete1 == "" | QueryComplejoCondicional1 == "" | QueryComplejoComp1 == "" | QueryComplejoOrden1 == "")
            {
                MessageBox.Show("No ha creado ninguna cadena");
            }
            else
            {
                if (AgregarCondiciones1.Checked)

                {
                    QueryComplejoTotal1 = QuerySimpleComplete1 + " " + QueryComplejoComp1 + " " + QueryComplejoCondicional1 + " " + QueryComplejoOrden1;
                    
                }
                else
                {
                    QueryComplejoTotal1 = QuerySimpleComplete1;
                    
                }

            }
            TxtEditarCadena.Text = QueryComplejoTotal1;
            log.EditarCampos(QueryComplejoTotal1, TxtNConsulta.Text, "Admin");
            MessageBox.Show("Consulta Editada con Exito!");
            limpiar();
            

        }

        private void BtnBuscarEditar_Click(object sender, EventArgs e)
        {
            if(TxtIdEditar.Text == "")
            {
                MessageBox.Show("Debe ingresar el nombre de la consulta para la busqueda");
            }
            else
            {
                string nombre = TxtIdEditar.Text;
                DataTable dtDatosDiseno = log.consultaId(nombre);
                dvgConsultas.DataSource = dtDatosDiseno;
            }
            

        }

        private void BtnEditarActualizar_Click(object sender, EventArgs e)
        {
            if (TxtIdEditar.Text == "")
            {
                MessageBox.Show("Debe ingresar el nombre de la consulta para actualizar");
            }
            else
            {
                string nombre = TxtIdEditar.Text;
                DataTable dtDatosDiseno = log.consultaId(nombre);
                dvgConsultas.DataSource = dtDatosDiseno;
            }
        }

        private void BtnEliminarEditar_Click(object sender, EventArgs e)
        {
            if(TxtIdEditar.Text == "")
            {
                MessageBox.Show("Debe ingresar el nombre de la consulta para eliminarlo");
            }
            else
            {
                string nombreconsulta = TxtIdEditar.Text;
                log.EliminarCampos(nombreconsulta);
            }

            /*string eliminar = "delete  where Id = " + TxtIdEditar.Text;

            if (cn.executecommand(eliminar))
            {
                MessageBox.Show("REGISTRO ELIMINADO EXITOSAMENTE");
                dvgConsultas.DataSource = cn.SelectDataTable("select * from datos");
            }

            else
            {
                MessageBox.Show("ERROR AL ELIMINAR");
            }*/
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            
            DataTable dtDatosDiseno = log.consultaId1();
            dvgConsultas.DataSource = dtDatosDiseno;

        }

        private void cboTablasGeneral_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cboCampos_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cboOpLogico_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cboCampoLogico_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cboComparador_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }


        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            log.EjecutarConsultas(dgvConsultas, textBox1.Text);
        }


        private void Cbo_ListaTablas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cbo_ListaTablas.Items.Count > 0)
            {
                int seleccionado = Cbo_ListaTablas.SelectedIndex;
                idConsulta = lista.ElementAt(seleccionado);
                textBox1.Text = consultas.ElementAt(seleccionado);
            }
        }

        private void BtnActualizar_Click(object sender, EventArgs e)
        {
            Cbo_ListaTablas.Items.Clear();
            lista.Clear();
            consultas.Clear();
            log.CargarConsultas(Cbo_ListaTablas, lista, consultas);
        }


        private void TbCreacionConsulta_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cboCampos.Items.Clear();
            //log.campos(CboGeneralCampos, cboTablaGeneral1.Text);
        }

        private void CboGeneralCampos_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void CheckBox1_Click(object sender, EventArgs e)
        {


            if (AgregarCondiciones1.Checked)
            {

                if (TxtNConsulta.Text == "" | CboGeneralCampos.Text == "" | cboTablaGeneral1.Text == "")
                {
                    MessageBox.Show("Debe Generar el Query Simple primero");
                }
                else
                {
                    gbLogica1.Enabled = true;
                    gbComparacion1.Enabled = true;
                    gbAgrupar1.Enabled = true;
                    gbTipoOrdenamiento1.Enabled = true;
                    log.campos(cboComparacionCampo, cboTablaGeneral1.Text);
                    log.campos(cboAgruparCampo, cboTablaGeneral1.Text);
                    log.campos(cboCondicionesCampo, cboTablaGeneral1.Text);

                }
            }
            else
            {
                gbLogica1.Enabled = false;
                gbComparacion1.Enabled = false;
                gbTipoOrdenamiento1.Enabled = false;
                gbAgrupar1.Enabled = false;
            }
        }

        private void CboComparacionTipo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void CboOrdenarAgrupar_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void CboTablaGeneral1_SelectedIndexChanged(object sender, EventArgs e)
        {
            CboGeneralCampos.Text = "";
            CboGeneralCampos.Items.Clear();
            log.campos(CboGeneralCampos, cboTablaGeneral1.Text);
        }

        private void GbGeneral1_Enter(object sender, EventArgs e)
        {

        }

        private void GbComparacion1_Enter(object sender, EventArgs e)
        {

        }

        private void Chkedit_CheckedChanged(object sender, EventArgs e)
        {
           
                CboGeneralCampos.Enabled = false;
                TxtNRepresentativoEdit.Enabled = false;
            
        }

        private void cboOpciones_Click(object sender, EventArgs e)
        {
            cboCampos.Enabled = false;
            txtNombreRepresentativo.Enabled = false;
        }

        private void CboGeneralCampos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CboAgruparCampo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cboOLogico_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void CboCampoSelectEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            log.campos(cboCampoSelectEdit, cboTablaGeneral1.Text);
        }

        private void CboCampos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AgregarCondiciones1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void GbComparacion_Enter(object sender, EventArgs e)
        {

        }

        private void cboCampoComparador_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cboTipoSeleccion_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void cboCampoOrden_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }



        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoSeleccion.Text == "Ordenar")
            {
                gbTipoOrdenamiento.Enabled = true;

            }
            else if (cboTipoSeleccion.Text == "Agrupar")
            {
                gbTipoOrdenamiento.Enabled = false;

            }
        }

        private void cboTipoSeleccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoSeleccion.Text == "Ordenar")
            {
                gbTipoOrdenamiento.Enabled = true;
               
            }
            else if (cboTipoSeleccion.Text == "Agrupar")
            {
                gbTipoOrdenamiento.Enabled = false;
                
            }



        }


        private void cbCondiciones_Click(object sender, EventArgs e)
        {

            if (cbCondiciones.Checked)
            {
                if (txtNombreConsulta.Text == "" | cboCampos.Text == "" | cboTablasGeneral.Text == "" )
                {
                    MessageBox.Show("Debe Generar el Query Simple primero");
                }
                else
                {
                    gbLogica.Enabled = true;
                    gbComparacion.Enabled = true;
                    gbTipoOrdenamiento.Enabled = true;
                    gbAgrupar.Enabled = true;
                    log.campos(cboCampoComparador, cboTablasGeneral.Text);
                    log.campos(cboCampoOrden, cboTablasGeneral.Text);
                    log.campos(cboCampoLogico, cboTablasGeneral.Text);
                }

            }
            else
            {
                gbLogica.Enabled = false;
                gbComparacion.Enabled = false;
                gbTipoOrdenamiento.Enabled = false;
                gbAgrupar.Enabled = false;
            }
            
           
        }

        private void btnAgregarComp_Click(object sender, EventArgs e) 
        {
            if (cboCampoComparador.Text == "" | cboComparador.Text == "" | txtValorComp.Text == "")
            {
                MessageBox.Show("Existen Campos Vacios");
            }
            else
            {
                ContadorComparacion++;
                if (ContadorComparacion > 1)
                {
                    MessageBox.Show("No puede agregar 2 comparaciones en un mismo query");
                }
                else
                {
                    QueryComplejoComp = cboComparador.Text+ " " + cboCampoComparador.Text + " = " + txtValorComp.Text;

                }
            }

            
        }

        private void btnAgregarCampo_Click(object sender, EventArgs e)
        {


            List<string> listacampos = new List<string>();

            if (cboOpciones.Checked)
            {
                if (txtNombreConsulta.Text == "" | cboTablasGeneral.Text == "")
                {
                    MessageBox.Show("Existen campos vacios");
                }
                else
                {
                    QuerySimple = " * ";
                    cboCampos.Enabled = false;
                    txtNombreRepresentativo.Enabled = false;
                    txtSeleccionados.Text = "Todos los campos han sido seleccionados";
                }

            }
            else
            {
                QuerySimple = "";
                cboCampos.Enabled = true;
                txtNombreRepresentativo.Enabled = true;
                txtSeleccionados.Text = "";
                if (txtNombreConsulta.Text == "" | cboCampos.Text == "" | cboTablasGeneral.Text == "" | txtNombreRepresentativo.Text == "")
                {


                    MessageBox.Show("No puede dejar campos vacíos");

                }

                else
                {
                    contadorAgregar++;
                    if (contadorAgregar == 1)
                    {
                
                            if (txtNombreRepresentativo.Text != " ")
                            {
                                QuerySimple += cboCampos.Text + " as " + txtNombreRepresentativo.Text;
                            }
                            else
                            {
                                QuerySimple += cboCampos.Text;
                            }
                    }
                    else if (contadorAgregar >= 1)
                    {

                        if (txtNombreRepresentativo.Text != "")
                        {
                            QuerySimple += "," + cboCampos.Text + " as " + txtNombreRepresentativo.Text;
                        }
                        else
                        {
                            QuerySimple += " ," + cboCampos.Text;
                        }

                    }


                    listacampos.Add(QuerySimple);
                    for (int j = 0; j < listacampos.Count; j++)
                    {
                        txtSeleccionados.Text = Convert.ToString(listacampos[j]);
                    }

                }
                //
            }

            //limpiar
        }

        public void limpiar()
        {
            QuerySimple = "";
            QueryComplejoTotal = "";
            QuerySimpleComplete = "";
            QueryComplejoComp = "";
            QueryComplejoCondicional = "";
            QueryComplejoOrden = "";
            TxtEditarCadena.Text = "";
            gbComparacion1.Enabled = false;
            gbLogica1.Enabled = false;
            gbAgrupar1.Enabled = false;

            TxtEditarCadena.Text = "";
            TxtEID.Text = "";
            TxtNConsulta.Text = "";
            TxtNRepresentativoEdit.Text = "";
            TxtCondicionesValor.Text = "";
            TxtComparaValor.Text = "";

            cboTablaGeneral1.Text = "";
            cboOLogico.Text = "";
            cboCondicionesCampo.Text = "";
            CboGeneralCampos.Text = "";
            cboCampoSelectEdit.Text = "";
            cboComparacionTipo.Text = "";
            cboComparacionCampo.Text = "";
            cboOrdenarAgrupar.Text = "";
            cboAgruparCampo.Text = "";

            cboTablaGeneral1.Items.Clear();
            cboOLogico.Items.Clear();
            cboCondicionesCampo.Items.Clear();
            CboGeneralCampos.Items.Clear();
            cboCampoSelectEdit.Items.Clear();
            cboComparacionTipo.Items.Clear();
            cboComparacionCampo.Items.Clear();
            cboOrdenarAgrupar.Items.Clear();
            cboAgruparCampo.Items.Clear();

        }

    }
}
