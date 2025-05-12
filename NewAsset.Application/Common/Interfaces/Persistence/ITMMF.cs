


namespace NewAsset.Application.Common.Interfaces.Persistence
{
    public interface ITMMF
    {
        IEnumerable<TMMFDetail> GetAllTMMF();
        TMMFDetail GetTMMFByID(int id);
        void AddTMMF(TMMFDetail tMMFDetail);
        void UpdateTMMF(TMMFDetail tMMFDetail);
        void DeleteTMMF(int id);
    }
}
