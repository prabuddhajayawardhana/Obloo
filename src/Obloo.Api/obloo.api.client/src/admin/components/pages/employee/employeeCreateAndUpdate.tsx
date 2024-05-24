import React from 'react';
import { useSelector, useDispatch } from 'react-redux';
import { RootState } from '../../../utils/store';
import { addEmployee } from '../../../behavior/employee/employeeSlice';
import TextFeild from '../../primitives/input/TextFeild';

const EmployeeCreateAndUpdate: React.FC = () => {
  const dispatch = useDispatch();
  const employee = useSelector((state: RootState) => state.employee);

  const handleOnChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const { name, value } = e.target;
    dispatch(addEmployee({ ...employee, [name]: value }));
  };

  return (
    <div>
      <h1>Any place in your app!</h1>
      <form>
        <TextFeild name="id" value={employee.id} onChange={handleOnChange} />
        <TextFeild
          name="name"
          value={employee.name}
          onChange={handleOnChange}
        />
        <button type="submit">Submit</button>
      </form>
    </div>
  );
};

export default EmployeeCreateAndUpdate;
