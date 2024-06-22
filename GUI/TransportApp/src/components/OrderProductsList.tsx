import React from "react";
type propTypes = {
  open: boolean;
  onClose: () => void;
  children: React.ReactNode;
};
function OrderProductsList(props: propTypes) {
  return <h1>Produkcior</h1>;
}

export default OrderProductsList;
