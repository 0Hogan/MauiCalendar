﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mauiCalendar.Data
{
    public class CalendarDatabase
    {
        SQLiteAsyncConnection Database;

        public CalendarDatabase()
        { }

        // Initialization of the database...
        private async Task Init()
        {
            // If the database is already loaded, go ahead and return.
            if (Database is not null)
                return;

            // Otherwise, open a connection to the database. If a CalendarEvent table doesn't already exist, create it.
            Database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            var result = await Database.CreateTableAsync<CalendarEvent>();
        }

        // Fetch all previous calculations from the database. cRud
        public async Task<List<CalendarEvent>> GetItemsAsync()
        {
            await Init();
            return await Database.Table<CalendarEvent>().ToListAsync();
        }

        // Save any modifications to an existing event or add a new event to the database. CrUd
        public async Task<int> SaveItemAsync(CalendarEvent calendarEvent)
        {
            await Init();
            if (calendarEvent.Id != 0)
            {
                return await Database.UpdateAsync(calendarEvent);
            }
            else
            {
                return await Database.InsertAsync(calendarEvent);
            }
        }

        // Delete an event from the database. cruD
        public async Task<int> DeleteEventAsync(CalendarEvent calendarEvent)
        {
            await Init();
            return await Database.DeleteAsync(calendarEvent);
        }

        // Clear the database.
        public async Task<int> DeleteHistoryAsync()
        {
            await Init();
            return await Database.DeleteAllAsync<CalendarEvent>();
        }
    }
}