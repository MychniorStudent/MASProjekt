function PickProducts() {
  return (
    <>
      <ul className="list-group list-group-horizontal ml-2">
        <li className="list-group-item col-sm-1">ID</li>
        <li className="list-group-item col-sm-2">Nazwa</li>
        <li className="list-group-item col-sm-2 ">Kategoria</li>
        <li className="list-group-item col-sm-2">Czy niebezpieczny</li>
        <li className="list-group-item col-sm-2 ">Wybor</li>
      </ul>
      <ul className="list-group list-group-horizontal ml-2">
        <li className="list-group-item col-sm-1">0</li>
        <li className="list-group-item col-sm-2">Nazwa</li>
        <li className="list-group-item col-sm-2 ">Kategoria</li>
        <li className="list-group-item col-sm-2">Nie</li>
        <li className="list-group-item col-sm-2 ">
          {" "}
          <input
            className="form-check-input"
            type="checkbox"
            value=""
            id="flexCheckDefault"
          />
        </li>
      </ul>
      <ul className="list-group list-group-horizontal ml-2">
        <li className="list-group-item col-sm-1">1</li>
        <li className="list-group-item col-sm-2">Nazwa</li>
        <li className="list-group-item col-sm-2 ">Kategoria</li>
        <li className="list-group-item col-sm-2">Tak</li>
        <li className="list-group-item col-sm-2 ">
          {" "}
          <input
            className="form-check-input"
            type="checkbox"
            value=""
            id="flexCheckDefault"
          />
        </li>
      </ul>
      <ul className="list-group list-group-horizontal ml-2">
        <li className="list-group-item col-sm-1">2</li>
        <li className="list-group-item col-sm-2">Nazwa</li>
        <li className="list-group-item col-sm-2 ">Kategoria</li>
        <li className="list-group-item col-sm-2">Tak</li>
        <li className="list-group-item col-sm-2 ">
          {" "}
          <input
            className="form-check-input"
            type="checkbox"
            value=""
            id="flexCheckDefault"
          />
        </li>
      </ul>
      <button type="submit" className="btn btn-success mt-2 w-25">
        {" "}
        Dodaj produkty
      </button>
    </>
  );
}

export default PickProducts;
