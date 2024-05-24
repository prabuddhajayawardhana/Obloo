import React, { ChangeEvent } from 'react';

interface TextFeildProps {
  name: string;
  value: string | number;
  onChange: (e: ChangeEvent<HTMLInputElement>) => void;
}

const TextFeild = ({ name, value, onChange }: TextFeildProps) => {
  return (
    <input
      id={name}
      name={name}
      type="text"
      value={value}
      onChange={onChange}
      className="block w-full rounded-md border-0 p-2 py-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6"
    />
  );
};

export default TextFeild;
