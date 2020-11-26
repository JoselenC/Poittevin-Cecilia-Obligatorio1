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
    public class BudgetMapper: IMapper<Budget, BudgetDto>
    {

        private List<BudgetCategoryDto> updateBudgetCategories(Budget obj, List<BudgetCategoryDto> budgetCategoriesDtos, DbContext context)
        {
            CategoryMapper categoryMapper = new CategoryMapper();
            List<BudgetCategory> newBudgetCategories = obj.BudgetCategories;

            if (!(budgetCategoriesDtos is null))
                foreach (BudgetCategoryDto budgetCategoryDto in budgetCategoriesDtos)
                {
                    context.Entry(budgetCategoryDto).State = EntityState.Modified;
                    context.Entry(budgetCategoryDto).Reference("Category").Load();
                    context.Entry(budgetCategoryDto.Category).State = EntityState.Unchanged;
                    BudgetCategory budgetCategory = newBudgetCategories.Find(x => x.Category.Name == budgetCategoryDto.Category.Name);

                    budgetCategoryDto.Amount = budgetCategory.Amount;
                    newBudgetCategories.Remove(budgetCategory);
                }
            else
                budgetCategoriesDtos = new List<BudgetCategoryDto>();
            foreach (BudgetCategory newBudgetCategory in newBudgetCategories)
            {
                budgetCategoriesDtos.Add(new BudgetCategoryDto()
                {
                    Amount = newBudgetCategory.Amount,
                    Category = categoryMapper.DomainToDto(newBudgetCategory.Category, context)
                });
            }
            return budgetCategoriesDtos;
        }
        public BudgetDto DomainToDto(Budget obj, DbContext context)
        {

            DbSet<BudgetDto> BudgetDtoSet = context.Set<BudgetDto>();
            BudgetDto budgetDto = BudgetDtoSet
                .Where(x => x.Month == (int)obj.Month)
                .Where(x => x.Year == obj.Year)
                .FirstOrDefault();
            if (budgetDto is null)
            {
                budgetDto = new BudgetDto()
                {
                    Month = (int)obj.Month,
                    TotalAmount = obj.TotalAmount,
                    Year = obj.Year,
                };
            }
            else
            {
                context.Entry(budgetDto).Collection("BudgetCategories").Load();
                context.Entry(budgetDto).State = EntityState.Modified;
            }

            budgetDto.BudgetCategories = updateBudgetCategories(obj, budgetDto.BudgetCategories, context);

            return budgetDto;
        }

        public Budget DtoToDomain(BudgetDto obj, DbContext context)
        {
            List<BudgetCategory> budgetCategories = new List<BudgetCategory>();
            CategoryMapper categoryMapper = new CategoryMapper();
            context.Entry(obj).Collection("BudgetCategories").Load();
            foreach (BudgetCategoryDto budgetCategory in obj.BudgetCategories)
            {
                context.Entry(budgetCategory).Reference("Category").Load();
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

        public BudgetDto UpdateDtoObject(BudgetDto objToUpdate, Budget updatedObject, DbContext contex)
        {
            throw new NotImplementedException();
        }
    }
}
