function PickTransport() {
  return (
    <>
      <ul className="list-group list-group-horizontal ml-2">
        <li className="list-group-item col-sm-1">ID</li>
        <li className="list-group-item col-sm-2">Marka</li>
        <li className="list-group-item col-sm-2 ">Model</li>
        <li className="list-group-item col-sm-2">Transport niebezpiecznych</li>
        <li className="list-group-item col-sm-2 ">Wybor</li>
      </ul>
      <ul className="list-group list-group-horizontal ml-2">
        <li className="list-group-item col-sm-1">0</li>
        <li className="list-group-item col-sm-2">Nazwa</li>
        <li className="list-group-item col-sm-2 ">Model</li>
        <li className="list-group-item col-sm-2">Tak</li>
        <li className="list-group-item col-sm-2 ">
          <button type="submit" className="btn btn-primary mt-2 ">
            {" "}
            Wybierz pojazd
          </button>
        </li>
      </ul>
      <ul className="list-group list-group-horizontal ml-2">
        <li className="list-group-item col-sm-1">1</li>
        <li className="list-group-item col-sm-2">Marka</li>
        <li className="list-group-item col-sm-2 ">Model</li>
        <li className="list-group-item col-sm-2">Tak</li>
        <li className="list-group-item col-sm-2 ">
          <button type="submit" className="btn btn-primary mt-2 ">
            {" "}
            Wybierz pojazd
          </button>
        </li>
      </ul>
      <ul className="list-group list-group-horizontal ml-2">
        <li className="list-group-item col-sm-1">2</li>
        <li className="list-group-item col-sm-2">Marka</li>
        <li className="list-group-item col-sm-2 ">Model</li>
        <li className="list-group-item col-sm-2">Tak</li>
        <li className="list-group-item col-sm-2 ">
          <button type="submit" className="btn btn-primary mt-2 ">
            {" "}
            Wybierz pojazd
          </button>
        </li>
      </ul>
    </>
  );
}

export default PickTransport;
