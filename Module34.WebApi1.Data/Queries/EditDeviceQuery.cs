namespace Module34.WebApi1.Data.Queries
{
    /// <summary>
    /// Класс для передачи дополнительных параметров при обновлении устройства
    /// </summary>
    public class EditDeviceQuery
    {
        public string NewName { get; }
        public string NewSerial { get; }

        public EditDeviceQuery(string newName = null, string newSerial = null)
        {
            NewName = newName;
            NewSerial = newSerial;
        }
    }
}