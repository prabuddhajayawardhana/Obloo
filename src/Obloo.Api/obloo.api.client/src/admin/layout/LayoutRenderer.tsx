import { ReactNode } from 'react';
import { Footer, Header, Sidebar } from '.';

export type Props = {
  children?: ReactNode;
};

const LayoutRenderer = ({ children }: Props) => {
  if (name == null) return children as JSX.Element;
  return (
    <div className="flex">
      <Sidebar />
      <Header />
      <div className="flex-1">{children}</div>
      <Footer />
    </div>
  );
};
export default LayoutRenderer;
