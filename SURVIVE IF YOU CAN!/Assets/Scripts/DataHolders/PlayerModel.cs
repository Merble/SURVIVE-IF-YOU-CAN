public class PlayerModel 
{
    private int _healthPoint = 100;
    private int _maxHP = 100;
    private int _minHP = 0;

    public int GetHealthPoint()
    {
        return _healthPoint;
    }

    public void ChangeHP(int hpChange)
    {
        _healthPoint += hpChange;
        if (_healthPoint > _maxHP)
        {
            _healthPoint = _maxHP;
        }
        else if (_healthPoint < _minHP)
        {
            _healthPoint = _minHP;
        }
    }
}
