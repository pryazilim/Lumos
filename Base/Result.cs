public class Result
  {
    public string? Message { get; set; }
    public bool Success { get; set; }
    public int? Statue { get; set; }


    public void SetError(string message)
    {
      Success = false;
      Message = message;
    }
    public void SetError(Exception ex)
    {
      Success = false;
      Message = ex.Message;
    }
    public void SetError()
    {
      Success = false;
      Message = "";
    }

    public void SetSuccess()
    {
      Success = true;
    }
    public void SetSuccess(string _message)
    {
      Success = true;
      Message = _message;
    }
  }

  public class Result<T> : Result
  {
    private List<T> resultList = new List<T>();

    public T? ResultObj { get; set; }

    public List<T> ResultList
    {
      get
      {
        return resultList;
      }
      set
      {
        resultList = value;
      }
    }


    public void SetSuccess(T Obj, List<T> List)
    {
      resultList = List;
      ResultObj = Obj;
      Success = true;
    }
    public void SetSuccess(List<T> List, T Obj)
    {
      resultList = List;
      ResultObj = Obj;
      Success = true;
    }
    public void SetSuccess(List<T> List)
    {
      resultList = List;
      Success = true;
    }
    public void SetSuccess(T Obj)
    {
      ResultObj = Obj;
      Success = true;
    }
  }
