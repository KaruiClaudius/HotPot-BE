using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Capstone.HPTY.ModelLayer.Entities;
using Capstone.HPTY.ServiceLayer.DTOs.Common;
using Microsoft.EntityFrameworkCore;

namespace Capstone.HPTY.ServiceLayer.Extensions
{
    public static class QueryableExtensions
    {
        public static async Task<PagedResult<T>> ToPagedResultAsync<T>(
            this IQueryable<T> query,
            PaginationParams paginationParams)
        {
            var totalCount = await query.CountAsync();

            var items = await query
                .Skip((paginationParams.PageNumber - 1) * paginationParams.PageSize)
                .Take(paginationParams.PageSize)
                .ToListAsync();

            return new PagedResult<T>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = paginationParams.PageNumber,
                PageSize = paginationParams.PageSize

            };
        }

        public static IQueryable<Order> ApplyFilters(this IQueryable<Order> query, OrderQueryParams queryParams)
        {
            // Apply status filter
            if (queryParams.Status.HasValue)
            {
                query = query.Where(o => o.Status == queryParams.Status.Value);
            }

            // Apply customer filter
            if (queryParams.CustomerId.HasValue)
            {
                query = query.Where(o => o.UserId == queryParams.CustomerId.Value);
            }

            // Apply date range filter
            if (queryParams.FromDate.HasValue)
            {
                query = query.Where(o => o.CreatedAt >= queryParams.FromDate.Value);
            }

            if (queryParams.ToDate.HasValue)
            {
                // Add one day to include the end date fully
                var endDate = queryParams.ToDate.Value.AddDays(1);
                query = query.Where(o => o.CreatedAt < endDate);
            }

            // Apply search term filter
            if (!string.IsNullOrWhiteSpace(queryParams.SearchTerm))
            {
                var searchTerm = queryParams.SearchTerm.ToLower();
                query = query.Where(o =>
                    o.Address.ToLower().Contains(searchTerm) ||
                    (o.Notes != null && o.Notes.ToLower().Contains(searchTerm)) ||
                    (o.User != null && o.User.Name.ToLower().Contains(searchTerm))
                );
            }

            return query;
        }

        public static IQueryable<Order> ApplySorting(this IQueryable<Order> query, OrderQueryParams queryParams)
        {
            if (string.IsNullOrWhiteSpace(queryParams.SortBy))
            {
                // Default sorting by creation date descending
                return query.OrderByDescending(o => o.CreatedAt);
            }

            // Apply sorting based on the provided field
            return queryParams.SortBy.ToLower() switch
            {
                "totalprice" => queryParams.SortDescending
                    ? query.OrderByDescending(o => o.TotalPrice)
                    : query.OrderBy(o => o.TotalPrice),
                "status" => queryParams.SortDescending
                    ? query.OrderByDescending(o => o.Status)
                    : query.OrderBy(o => o.Status),
                "date" => queryParams.SortDescending
                    ? query.OrderByDescending(o => o.CreatedAt)
                    : query.OrderBy(o => o.CreatedAt),
                "customer" => queryParams.SortDescending
                    ? query.OrderByDescending(o => o.User.Name)
                    : query.OrderBy(o => o.User.Name),
                _ => queryParams.SortDescending
                    ? query.OrderByDescending(o => o.CreatedAt)
                    : query.OrderBy(o => o.CreatedAt)
            };
        }

        public static IQueryable<ShippingOrder> ApplyFilters(this IQueryable<ShippingOrder> query, ShippingOrderQueryParams queryParams)
        {
            // Apply IsDelivered filter
            if (queryParams.IsDelivered.HasValue)
            {
                query = query.Where(so => so.IsDelivered == queryParams.IsDelivered.Value);
            }

            // Apply StaffId filter
            if (queryParams.StaffId.HasValue)
            {
                query = query.Where(so => so.StaffId == queryParams.StaffId.Value);
            }

            // Apply date range filter
            if (queryParams.FromDate.HasValue)
            {
                query = query.Where(so => so.CreatedAt >= queryParams.FromDate.Value);
            }

            if (queryParams.ToDate.HasValue)
            {
                // Add one day to include the end date fully
                var endDate = queryParams.ToDate.Value.AddDays(1);
                query = query.Where(so => so.CreatedAt < endDate);
            }

            // Apply search term filter
            if (!string.IsNullOrWhiteSpace(queryParams.SearchTerm))
            {
                var searchTerm = queryParams.SearchTerm.ToLower();
                query = query.Where(so =>
                    (so.Order != null && so.Order.Address.ToLower().Contains(searchTerm)) ||
                    (so.DeliveryNotes != null && so.DeliveryNotes.ToLower().Contains(searchTerm)) ||
                    (so.Staff != null && so.Staff.Name.ToLower().Contains(searchTerm)) ||
                    (so.Order != null && so.Order.User != null && so.Order.User.Name.ToLower().Contains(searchTerm))
                );
            }

            return query;
        }

        public static IQueryable<ShippingOrder> ApplySorting(this IQueryable<ShippingOrder> query, ShippingOrderQueryParams queryParams)
        {
            if (string.IsNullOrWhiteSpace(queryParams.SortBy))
            {
                // Default sorting by creation date descending
                return query.OrderByDescending(so => so.CreatedAt);
            }

            // Apply sorting based on the provided field
            return queryParams.SortBy.ToLower() switch
            {
                "isdelivered" => queryParams.SortDescending
                    ? query.OrderByDescending(so => so.IsDelivered)
                    : query.OrderBy(so => so.IsDelivered),
                "deliverytime" => queryParams.SortDescending
                    ? query.OrderByDescending(so => so.DeliveryTime)
                    : query.OrderBy(so => so.DeliveryTime),
                "date" => queryParams.SortDescending
                    ? query.OrderByDescending(so => so.CreatedAt)
                    : query.OrderBy(so => so.CreatedAt),
                "staff" => queryParams.SortDescending
                    ? query.OrderByDescending(so => so.Staff.Name)
                    : query.OrderBy(so => so.Staff.Name),
                "customer" => queryParams.SortDescending
                    ? query.OrderByDescending(so => so.Order.User.Name)
                    : query.OrderBy(so => so.Order.User.Name),
                _ => queryParams.SortDescending
                    ? query.OrderByDescending(so => so.CreatedAt)
                    : query.OrderBy(so => so.CreatedAt)
            };
        }

        public static IQueryable<Vehicle> ApplyFilters(this IQueryable<Vehicle> query, VehicleQueryParams queryParams)
        {
            // Apply Type filter
            if (queryParams.Type.HasValue)
            {
                query = query.Where(v => v.Type == queryParams.Type.Value);
            }

            // Apply Status filter
            if (queryParams.Status.HasValue)
            {
                query = query.Where(v => v.Status == queryParams.Status.Value);
            }

            // Apply search term filter for Name and LicensePlate
            if (!string.IsNullOrWhiteSpace(queryParams.SearchTerm))
            {
                var searchTerm = queryParams.SearchTerm.ToLower();
                query = query.Where(v =>
                    v.Name.ToLower().Contains(searchTerm) ||
                    v.LicensePlate.ToLower().Contains(searchTerm)
                );
            }

            return query;
        }
        public static IQueryable<Vehicle> ApplySorting(this IQueryable<Vehicle> query, VehicleQueryParams queryParams)
        {
            if (string.IsNullOrWhiteSpace(queryParams.SortBy))
            {
                // Default sorting by VehicleId
                return query.OrderBy(v => v.VehicleId);
            }

            // Apply sorting based on the provided field (only Type, Status, and VehicleId)
            return queryParams.SortBy.ToLower() switch
            {
                "vehicleid" => queryParams.SortDescending
                    ? query.OrderByDescending(v => v.VehicleId)
                    : query.OrderBy(v => v.VehicleId),
                "type" => queryParams.SortDescending
                    ? query.OrderByDescending(v => v.Type)
                    : query.OrderBy(v => v.Type),
                "status" => queryParams.SortDescending
                    ? query.OrderByDescending(v => v.Status)
                    : query.OrderBy(v => v.Status),
                _ => query.OrderBy(v => v.Type) // Default sorting
            };
        }

    }
}