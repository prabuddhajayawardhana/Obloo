import { ReactNode, memo } from 'react';
import { Footer, Header, Sidebar } from '.';

type Props = {
  children?: ReactNode;
};

const LayoutRenderer = ({ children }: Props) => {
  if (name == null)
    return children as JSX.Element;

  // const Layout = layoutRenderers[name];
  // if (!Layout)
  //   throw new Error(`Layout renderer "${name}" is not registered.`);

  return (
    <div className="flex">
    <Sidebar />
    <Header />
    <div className="flex-1">{children}</div>
    <Footer />
  </div>
  )
};

export default memo(LayoutRenderer);

