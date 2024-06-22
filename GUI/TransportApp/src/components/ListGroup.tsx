import { useState } from "react";
function ListGroup() {
  let items = ["New York", "Warsaw", "Tokyo", "London", "Paris"];

  const getMessage = () => {
    return items.length === 0 ? <p>No items found</p> : null;
  };

  const [selectedIndex, setSelectedIndex] = useState(-1);

  return (
    <>
      <h1>List</h1>
      {getMessage()}
      <ul className="list-group">
        {items.map((item, index) => (
          <li
            className={
              selectedIndex === index
                ? "list-group-item active"
                : "list-group-item"
            }
            key={item}
            onClick={() => {
              setSelectedIndex(index);
            }}
          >
            {item}
          </li>
        ))}
      </ul>
    </>
  );
}

export default ListGroup;
