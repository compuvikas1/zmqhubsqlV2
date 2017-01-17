SELECT Symbol, UpdateTime, CONVERT(VARCHAR(10),ExpiryDate,105) ExpiryDate, OptType, StrikePrice, Exch, PCloseRate, LastRate, TotalQty, Series, MLot, ScripNo, OpenRate, HighRate, LowRate, AvgRate FROM LPReliableMap.dbo.vwFeedV1

select * from LPINTRADAY.dbo.TouchLine

select * from LPRELIABLEMAP.dbo.FAOMaster 
Where series in ('FUTSTK', 'OPTSTK')
order by symbol, ExpiryDate, StrikePrice

select ScripNo, Exch, RTrim(Series) series, RTrim(Symbol) symbol ,RTrim(OptType) opttype,StrikePrice,ExpiryDate,MLot 
from LPRELIABLEMAP.dbo.FAOMaster 
Where series in ('FUTSTK', 'OPTSTK', 'FUTIDX', 'OPTIDX')
order by Exch,symbol, ExpiryDate, StrikePrice

select distinct(series) from LPRELIABLEMAP.dbo.FAOMaster
where Symbol = 'NIFTY'

select distinct(expiryDate) from LPRELIABLEMAP.dbo.FAOMaster
where Symbol = 'ACC' and Exch = 'NFO' and RTRIM(series) = 'FUTSTK'

select distinct(expiryDate) from LPRELIABLEMAP.dbo.FAOMaster
where Symbol = 'ACC' and Exch = 'NOP' and RTRIM(series) = 'OPTSTK'
