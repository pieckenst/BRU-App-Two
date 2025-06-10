using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Burdukov_kurs
{
    public partial class UserManagementForm : Form
    {
        private User currentUserEditing; // Для хранения пользователя, которого редактируем

        public UserManagementForm()
        {
            InitializeComponent();
            LoadUsers();
        }

        private void LoadUsers()
        {
            dgvUsers.DataSource = null;
            dgvUsers.DataSource = UserService.ReadUsersFromFile();
            SetupDataGridViewColumns();
            ClearInputFields();
        }

        private void SetupDataGridViewColumns()
        {
            if (dgvUsers.Columns.Count > 0)
            {
                dgvUsers.Columns["Username"].HeaderText = "Логин";
                dgvUsers.Columns["Password"].HeaderText = "Пароль"; // В реальном приложении пароли не должны отображаться
                dgvUsers.Columns["Role"].HeaderText = "Роль";
                dgvUsers.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Логин и пароль не могут быть пустыми.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            UserRole role = rbAdmin.Checked ? UserRole.Administrator : UserRole.User;
            var newUser = new User(txtUsername.Text, txtPassword.Text, role);

            if (UserService.AddUser(newUser))
            {
                MessageBox.Show("Пользователь успешно добавлен.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadUsers();
            }
            else
            {
                MessageBox.Show("Пользователь с таким логином уже существует.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            if (currentUserEditing == null)
            {
                MessageBox.Show("Выберите пользователя для редактирования.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Логин и пароль не могут быть пустыми.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            UserRole role = rbAdmin.Checked ? UserRole.Administrator : UserRole.User;
            var updatedUser = new User(txtUsername.Text, txtPassword.Text, role);

            // Проверка, если это последний администратор и его пытаются сделать обычным пользователем
            if (currentUserEditing.Role == UserRole.Administrator && updatedUser.Role == UserRole.User)
            {
                if (UserService.ReadUsersFromFile().Count(u => u.Role == UserRole.Administrator && u.Username != currentUserEditing.Username) == 0)
                {
                    MessageBox.Show("Нельзя изменить роль единственного администратора.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            if (UserService.UpdateUser(currentUserEditing.Username, updatedUser))
            {
                MessageBox.Show("Данные пользователя успешно обновлены.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadUsers();
            }
            else
            {
                MessageBox.Show("Не удалось обновить данные пользователя. Возможно, новый логин уже занят или пользователь не найден.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count > 0)
            {
                string usernameToDelete = dgvUsers.SelectedRows[0].Cells["Username"].Value.ToString();

                if (MessageBox.Show($"Вы действительно хотите удалить пользователя '{usernameToDelete}'?", "Подтверждение удаления", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (UserService.DeleteUser(usernameToDelete))
                    {
                        MessageBox.Show("Пользователь успешно удален.", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadUsers();
                    }
                    else
                    {
                        MessageBox.Show("Не удалось удалить пользователя. Возможно, это единственный администратор.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Выберите пользователя для удаления.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvUsers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count > 0)
            {
                var selectedRow = dgvUsers.SelectedRows[0];
                txtUsername.Text = selectedRow.Cells["Username"].Value.ToString();
                txtPassword.Text = selectedRow.Cells["Password"].Value.ToString(); // Показ пароля для редактирования
                UserRole role = (UserRole)selectedRow.Cells["Role"].Value;
                if (role == UserRole.Administrator)
                {
                    rbAdmin.Checked = true;
                }
                else
                {
                    rbUser.Checked = true;
                }
                currentUserEditing = new User(txtUsername.Text, txtPassword.Text, role);
                btnEditUser.Enabled = true;
                btnDeleteUser.Enabled = true;
            }
            else
            {
                ClearInputFields();
                currentUserEditing = null;
                btnEditUser.Enabled = false;
                btnDeleteUser.Enabled = false;
            }
        }

        private void ClearInputFields()
        {
            txtUsername.Clear();
            txtPassword.Clear();
            rbUser.Checked = true; // По умолчанию - пользователь
            currentUserEditing = null;
            dgvUsers.ClearSelection();
            btnEditUser.Enabled = false;
            btnDeleteUser.Enabled = false;
        }

        private void btnClearFields_Click(object sender, EventArgs e)
        {
            ClearInputFields();
        }
    }
}