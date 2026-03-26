using ApiCoreCrudDepartamentos.Data;
using ApiCoreCrudDepartamentos.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.Arm;
using System.Threading.Tasks;

namespace ApiCoreCrudDepartamentos.Repositories
{
    public class RepositoryDepartamentos
    {
        private DepartamentosContext context;

        public RepositoryDepartamentos(DepartamentosContext context)
        {
            this.context = context;
        }

        public async Task<List<Departamento>> GetDepartamentosAsync()
        {
            return await this.context.Departamentos
                .ToListAsync();
        }

        public async Task<Departamento> FindDepartamentoAsync(int idDepartamento)
        {
            return await this.context.Departamentos
                .FirstOrDefaultAsync(d => d.IdDepartamento == idDepartamento);
        }

        public async Task CreateDepartamentoAsync(Departamento dep)
        {
            await this.context.Departamentos.AddAsync(dep);
            await this.context.SaveChangesAsync();
        }

        public async Task EditDepartamentoAsync(Departamento dep)
        {
            Departamento departamento = await this.FindDepartamentoAsync(dep.IdDepartamento);
            if(departamento != null)
            {
                departamento.Nombre = dep.Nombre;
                departamento.Localidad = dep.Localidad;
                await this.context.SaveChangesAsync();
            }
        }

        public async Task DeleteDepartamentoAsync(int idDepartamento)
        {
            Departamento departamento = await this.FindDepartamentoAsync(idDepartamento);
            this.context.Departamentos.Remove(departamento);
            await this.context.SaveChangesAsync();
        }

    }
}
