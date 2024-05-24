import { createSlice, PayloadAction } from '@reduxjs/toolkit';

interface Employee {
  id: number;
  name: string;
}

const initialState: Employee = { id: 1, name: 'Prabudha' };

export const employeeSlice = createSlice({
  name: 'employee',
  initialState,
  reducers: {
    addEmployee: (state, action: PayloadAction<Employee>) => {
      return action.payload; // Replace the state with the new employee
    },
  },
});

// Exporting actions
export const { addEmployee } = employeeSlice.actions;

export default employeeSlice.reducer;
