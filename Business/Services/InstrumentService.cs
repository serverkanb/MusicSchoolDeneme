using AppCore.Business.Services.Bases;
using AppCore.Results.Bases;
using AppCore.Results;
using Business.Models;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace Business.Services
{


    public interface IInstrumentService : IService<InstrumentModel>
    {

    }

    public class InstrumentService : IInstrumentService
    {
        private readonly InstrumentRepoBase _instrumentRepo;

        public InstrumentService(InstrumentRepoBase instrumentRepo)
        {
            _instrumentRepo = instrumentRepo;
        }

        public Result Add(InstrumentModel model)
        {

            if (_instrumentRepo.Exists(i => i.Name.ToLower() == model.Name.ToLower().Trim()))
                return new ErrorResult("instrument with same name exists!");


            Instrument entity = new Instrument()
            {
                Id=model.Id,
                Name = model.Name.Trim(),
                StockAmount = model.StockAmount.Value,
                UnitPrice = model.UnitPrice.Value,

            };
            _instrumentRepo.Add(entity);
            return new SuccessResult("Instrument added successfully.");
        }

        public Result Delete(int id)
        {

            Instrument existingInstrument = _instrumentRepo.Query().SingleOrDefault(i => i.Id == id);
            if (existingInstrument == null)
            {
                return new ErrorResult("Record not found!");
            }
            _instrumentRepo.Delete(id);
            return new SuccessResult("Record deleted successfully.");
        }

        public void Dispose()
        {
            _instrumentRepo.Dispose();
        }

        public IQueryable<InstrumentModel> Query()
        {
            return _instrumentRepo.Query().Select(i => new InstrumentModel()
            {
                Id = i.Id,
                Name = i.Name,
                StockAmount = i.StockAmount.Value,
                UnitPrice = i.UnitPrice
            });
        }
        public Result Update(InstrumentModel model)
        {
            if (_instrumentRepo.Exists(i => i.Name.ToLower() == model.Name.ToLower().Trim() && i.Id != model.Id))
                return new ErrorResult("Instrument with same name exists!");

            Instrument entity = new Instrument()
            {
                Id = model.Id,
                Name = model.Name.Trim(),
                StockAmount = model.StockAmount.Value,
                UnitPrice = model.UnitPrice.Value
            };
            _instrumentRepo.Update(entity);
            return new SuccessResult("Instrument updated sucessfully.");
        }
    }
}
