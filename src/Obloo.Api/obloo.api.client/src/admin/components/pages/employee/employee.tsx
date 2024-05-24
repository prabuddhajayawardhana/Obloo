import { Link } from 'react-router-dom';

const EmployeeList = () => {
  // eslint-disable-next-line react-hooks/rules-of-hooks
  // const employees = useSelector((state: RootState) => state.employee);

  return (
    <>
      <Link to={`create`}>Create</Link>
      {/* {employees.map((employee) => (
        <h1 key={employee.id}>{employee.name}</h1>
      ))} */}
    </>
  );
};

export default EmployeeList;
