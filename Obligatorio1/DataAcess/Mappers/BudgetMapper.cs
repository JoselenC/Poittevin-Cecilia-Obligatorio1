using BusinessLogic;
using DataAccess.Mappers;
using DataAcess.DBObjects;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Mappers
{
    class BudgetMapper: IMapper<Budget, BudgetDto>
    {
        public BudgetDto DomainToDto(Budget obj)
        {
            List<BudgetCategoryDto> budgetCategories = new List<BudgetCategoryDto>();
            CategoryMapper categoryMapper = new CategoryMapper();
            // TODO: BudgetCategory, deberia tener su propio mapper? Si no lo usa mas nadie que Budget, no creo que sea necesario
            // en ese caso hay que agregarlo a la doc, Si se usa fuera de Budget, tendremos que crearle un mapper y usarlo aca (al igual que el de category)
            foreach (BudgetCategory budgetCategory in obj.BudgetCategories)
            {
                budgetCategories.Add(new BudgetCategoryDto() {
                    Category = categoryMapper.DomainToDto(budgetCategory.Category),
                    Amount = budgetCategory.Amount
                });
            }
            return new BudgetDto() {
                Month = (int)obj.Month,
                TotalAmount = obj.TotalAmount,
                Year = obj.Year,
            };
        }

        public Budget DtoToDomain(BudgetDto obj, DbContext context)
        {
            List<BudgetCategory> budgetCategories = new List<BudgetCategory>();
            CategoryMapper categoryMapper = new CategoryMapper();
            // TODO: BudgetCategory, deberia tener su propio mapper? Si no lo usa mas nadie que Budget, no creo que sea necesario
            // en ese caso hay que agregarlo a la doc, Si se usa fuera de Budget, tendremos que crearle un mapper y usarlo aca (al igual que el de category)
            context.Entry(obj).Collection("BudgetCategories").Load();
            foreach (BudgetCategoryDto budgetCategory in obj.BudgetCategories)
            {
                budgetCategories.Add(new BudgetCategory()
                {
                    Category = categoryMapper.DtoToDomain(budgetCategory.Category, context),
                    Amount = budgetCategory.Amount
                });
            }
            return new Budget((Months)obj.Month)
            {
                TotalAmount = obj.TotalAmount,
                Year = obj.Year,
                BudgetCategories = budgetCategories
            };
        }
    }
}
