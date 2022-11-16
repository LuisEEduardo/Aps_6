namespace App.DTO
{
    public class ReconhecimentoFacialDTO
    {
        //public ReconhecimentoFacialDTO(string filePath)
        //{
        //    FilePath = $@"C:\dev\faculdade\aps_6_semestre\Aps6\App\wwwroot\CameraPhotos\{filePath.Substring(2).Remove(40).Remove(39)}";
        //}

        public string FilePath { get; set; }
        public int Id { get; set; }

    }
}
