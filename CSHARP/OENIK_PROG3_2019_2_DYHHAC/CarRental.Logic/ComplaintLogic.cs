// <copyright file="ComplaintLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CarRental.Logic
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using CarRental.Data;
    using CarRental.Repository;

    /// <summary>
    /// This class is responsible for the CRUD operations of the Complaints table.
    /// </summary>
    public class ComplaintLogic : IComplaintLogic
    {
        private IRepository<Complaint, int> complaintRepo;

        /// <summary>
        /// Initializes a new instance of the <see cref="ComplaintLogic"/> class.
        /// </summary>
        /// <param name="complaints">The repository that handles the complaints table.</param>
        public ComplaintLogic(IRepository<Complaint, int> complaints)
        {
            this.complaintRepo = complaints;
        }

        /// <inheritdoc/>
        public bool AddNewComplaint(int rentId, string desc, DateTime time, int chk)
        {
            Complaint comp = new Complaint()
            {
                RentId = rentId,
                Description = desc,
                Time = time,
                Chk = chk,
            };

            if (time == DateTime.MinValue)
            {
                return false;
            }

            try
            {
                this.complaintRepo.Add(comp);
                return true;
            }
            catch (ArgumentNullException)
            {
                return false;
            }
            catch (InvalidOperationException)
            {
                return false;
            }
        }

        /// <inheritdoc/>
        public bool DeleteComplaintData(int id)
        {
            try
            {
                this.complaintRepo.Delete(id);
                return true;
            }
            catch (ArgumentNullException)
            {
                return false;
            }
            catch (InvalidOperationException)
            {
                return false;
            }
        }

        /// <inheritdoc/>
        public IQueryable<Complaint> GetComplaintData()
        {
            return this.complaintRepo.GetAll();
        }

        /// <inheritdoc/>
        public bool IsValidComplaint(int id)
        {
            try
            {
                this.complaintRepo.GetOne(id);
                return true;
            }
            catch (ArgumentNullException)
            {
                return false;
            }
            catch (InvalidOperationException)
            {
                return false;
            }
        }

        /// <inheritdoc/>
        public bool UpdateComplaintData(int id, int rentId, string desc, DateTime time, int chk)
        {
            if (this.IsValidComplaint(id))
            {
                Complaint c = new Complaint()
                {
                    RentId = rentId,
                    Description = desc,
                    Time = time,
                    Chk = chk,
                };
                this.complaintRepo.Update(id, c);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
