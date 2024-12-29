internal class InheemseSoortRepository
{
    private readonly List<InheemseSoort> _soorten = new();

    public void VoegInheemseSoortToe(InheemseSoort soort)
    {
        _soorten.Add(soort);
    }

    public List<InheemseSoort> HaalAlleInheemseSoortenOp()
    {
        return _soorten;
    }
}