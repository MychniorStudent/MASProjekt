function AddTransport() {
  return (
    <>
      <form>
        <div className="row mt-2">
          <div className="col">
            <input type="text" className="form-control" placeholder="Marka" />
          </div>
        </div>
        <div className="row mt-2">
          <div className="col">
            <input type="text" className="form-control" placeholder="Model" />
          </div>
        </div>
        <div className="row mt-2">
          <div className="col">
            <input
              type="text"
              className="form-control"
              placeholder="Numer rejestracyjny"
            />
          </div>
        </div>
        <div className="row mt-2">
          <div className="col">
            <input
              className="form-check-input"
              type="checkbox"
              value=""
              id="flexCheckDefault"
            />
            <label className="form-check-label" htmlFor="flexCheckDefault">
              Czy pojazd wodny?
            </label>
          </div>
        </div>
        <div className="row mt-2">
          <div className="col">
            <input
              className="form-check-input"
              type="checkbox"
              value=""
              id="flexCheckDefault"
            />
            <label className="form-check-label" htmlFor="flexCheckDefault">
              Czy pojazd może przewozić niebezpieczne produkty?
            </label>
          </div>
        </div>
        <div className="row mt-2">
          <div className="col">
            <button type="submit" className="btn btn-success">
              {" "}
              Dodaj pojazd
            </button>
          </div>
        </div>
      </form>
    </>
  );
}

export default AddTransport;
